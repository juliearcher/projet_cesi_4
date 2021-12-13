using API.Configuration;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers
{
	[Route("api/inventories")]
	[ApiController]
	public class InventoryController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public InventoryController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/inventories
		[HttpGet]
		public ActionResult<IEnumerable<InventoryReadDto>> GetAllInventorys()
		{
			var inventoryList = _unitOfWork.InventoryRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<InventoryReadDto>>(inventoryList));
		}

		// GET api/inventories/{id}
		[HttpGet("{id}", Name = "GetInventoryById")]
		public ActionResult<IEnumerable<InventoryReadDto>> GetInventoryById(int id)
		{
			var inventory = _unitOfWork.InventoryRepository.GetSingle(item => item.Id == id, item => item.InventoryLines);
			return inventory != null ? Ok(_mapper.Map<InventoryReadDto>(inventory)) : NotFound();
		}

		//POST api/inventories
		[HttpPost]
		public ActionResult<InventoryReadDto> CreateInventory(InventoryCreateDto inventoryCreateDto)
		{
			// TODO check if infos are valid
			var inventoryModel = _mapper.Map<Inventory>(inventoryCreateDto);
			_unitOfWork.InventoryRepository.Add(inventoryModel);
			_unitOfWork.SaveChanges();
			var inventoryReadDto = _mapper.Map<InventoryReadDto>(inventoryModel);
			return CreatedAtRoute(nameof(GetInventoryById), new { Id = inventoryReadDto.Id }, inventoryReadDto);
		}

		// PUT api/inventories/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateInventory(int id, InventoryUpdateDto inventoryUpdateDto)
		{
			// TODO check if infos are valid
			var inventory = _unitOfWork.InventoryRepository.GetSingle(id);
			if (inventory == null)
				return NotFound();
			_mapper.Map(inventoryUpdateDto, inventory);
			_unitOfWork.InventoryRepository.Update(inventory);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// PATCH api/inventories/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<InventoryUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var inventory = _unitOfWork.InventoryRepository.GetSingle(id);
			if (inventory == null)
				return NotFound();
			var inventoryUpdateDto = _mapper.Map<InventoryUpdateDto>(inventory);
			patchDocument.ApplyTo(inventoryUpdateDto, ModelState);
			if (!TryValidateModel(inventoryUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(inventoryUpdateDto, inventory);
			_unitOfWork.InventoryRepository.Update(inventory);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// DELETE api/inventories/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var inventory = _unitOfWork.InventoryRepository.GetSingle(id);
			if (inventory == null)
				return NotFound();
			_unitOfWork.InventoryRepository.Delete(inventory);
			_unitOfWork.SaveChanges();
			return NoContent();
		}
	}
}