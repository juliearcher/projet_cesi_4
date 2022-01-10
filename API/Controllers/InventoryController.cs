using API.Configuration;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
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
			if (inventory.DocumentState == (int)Inventory.InventoryState.Validated)
				return BadRequest(new { title = "Erreur", errors = "Inventaire déjà validé, impossible de modifier." });
			_mapper.Map(inventoryUpdateDto, inventory);
			_unitOfWork.InventoryRepository.Update(inventory);
			try
			{
				UpdateInventoryLines(inventoryUpdateDto.InventoryLines, id);
				if (inventory.DocumentState == (int)Inventory.InventoryState.Validated)
					UpdateItemStock(id);
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
			return NoContent();
		}

		private void UpdateInventoryLines(IEnumerable<InventoryLineUpdateDto> inventoryLineDtos, int inventoryId)
		{
			InventoryLine line;
			InventoryLineUpdateDto line2;
			int i;
			List<InventoryLine> inventoryLines = (List<InventoryLine>)(_unitOfWork.InventoryLineRepository.FindBy(inventoryLine => inventoryLine.InventoryId == inventoryId).OrderBy(line => line.LineOrder))?.ToList();
			inventoryLineDtos = (List<InventoryLineUpdateDto>)inventoryLineDtos.OrderBy(line => line.LineOrder)?.ToList();
			if (inventoryLineDtos == null)
				inventoryLineDtos = new List<InventoryLineUpdateDto>();
			if (inventoryLines == null)
				inventoryLines = new List<InventoryLine>();

			for (i = 0; i < inventoryLineDtos.Count() && i < inventoryLines.Count(); ++i)
			{
				line = inventoryLines.ElementAt(i);
				line2 = inventoryLineDtos.ElementAt(i);

				_mapper.Map(inventoryLineDtos.ElementAt(i), inventoryLines.ElementAt(i));
				inventoryLines.ElementAt(i).LineOrder = i;
			}
			if (i < inventoryLineDtos.Count())
			{
				for (; i < inventoryLineDtos.Count(); ++i)
				{
					line = _mapper.Map<InventoryLine>(inventoryLineDtos.ElementAt(i));
					line.InventoryId = inventoryId;
					line.LineOrder = i;
					line.CreatedUser = inventoryLineDtos.ElementAt(i).ModifiedUser;
					_unitOfWork.InventoryLineRepository.Add(line);
					((List<InventoryLine>)inventoryLines).Add(line);
				}
			}
			else if (i < inventoryLines.Count())
			{
				while (i < inventoryLines.Count())
				{
					_unitOfWork.InventoryLineRepository.Delete(inventoryLines.ElementAt(i));
					((List<InventoryLine>)inventoryLines).RemoveAt(i);

				}
			}
		}

		// PATCH api/inventories/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<InventoryUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var inventory = _unitOfWork.InventoryRepository.GetSingle(id);
			if (inventory == null)
				return NotFound();
			if (inventory.DocumentState == (int)Inventory.InventoryState.Validated)
				return BadRequest(new { title = "Erreur", errors = "Inventaire déjà validé, impossible de modifier." });
			var inventoryUpdateDto = _mapper.Map<InventoryUpdateDto>(inventory);
			patchDocument.ApplyTo(inventoryUpdateDto, ModelState);
			if (!TryValidateModel(inventoryUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(inventoryUpdateDto, inventory);
			if (inventory.DocumentState == (int)Inventory.InventoryState.Validated)
				UpdateItemStock(id);
			_unitOfWork.InventoryRepository.Update(inventory);
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
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
			if (inventory.DocumentState == (int)Inventory.InventoryState.Validated)
				return BadRequest(new { title = "Erreur", errors = "Inventaire déjà validé, impossible de supprimer." });
			_unitOfWork.InventoryRepository.Delete(inventory);
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
			return NoContent();
		}

		private void UpdateItemStock(int id)
		{
			List<InventoryLine> inventoryLines = (List<InventoryLine>)(_unitOfWork.InventoryLineRepository.FindBy(inventoryLine => inventoryLine.InventoryId == id).OrderBy(line => line.LineOrder))?.ToList();
			if (inventoryLines == null)
				return;
			foreach (InventoryLine line in inventoryLines)
			{
				var item = _unitOfWork.ItemRepository.GetSingle((int)line.ItemId);
				item.VirtualStock = line.NewStock + item.VirtualStock - item.RealStock;
				item.RealStock = line.NewStock;
				_unitOfWork.ItemRepository.Update(item);
			}
		}
	}
}