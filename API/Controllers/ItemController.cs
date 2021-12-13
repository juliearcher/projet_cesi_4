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
	[Route("api/items")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ItemController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/items
		[HttpGet]
		public ActionResult<IEnumerable<ItemReadDto>> GetAllItems()
		{
			var itemList = _unitOfWork.ItemRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(itemList));
		}

		// GET api/items/{id}
		[HttpGet("{id}", Name = "GetItemById")]
		public ActionResult<IEnumerable<ItemReadDto>> GetItemById(int id)
		{
			var item = _unitOfWork.ItemRepository.GetSingle(id);
			return item != null ? Ok(_mapper.Map<ItemReadDto>(item)) : NotFound();
		}

		//POST api/items
		[HttpPost]
		public ActionResult<ItemReadDto> CreateItem(ItemCreateDto itemCreateDto)
		{
			// TODO check if infos are valid
			var itemModel = _mapper.Map<Item>(itemCreateDto);
			_unitOfWork.ItemRepository.Add(itemModel);
			_unitOfWork.SaveChanges();
			var itemReadDto = _mapper.Map<ItemReadDto>(itemModel);
			return CreatedAtRoute(nameof(GetItemById), new { Id = itemReadDto.Id }, itemReadDto);
		}

		// PUT api/items/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateItem(int id, ItemUpdateDto itemUpdateDto)
		{
			// TODO check if infos are valid
			var item = _unitOfWork.ItemRepository.GetSingle(id);
			if (item == null)
				return NotFound();
			_mapper.Map(itemUpdateDto, item);
			_unitOfWork.ItemRepository.Update(item);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// PATCH api/items/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<ItemUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var item = _unitOfWork.ItemRepository.GetSingle(id);
			if (item == null)
				return NotFound();
			var itemUpdateDto = _mapper.Map<ItemUpdateDto>(item);
			patchDocument.ApplyTo(itemUpdateDto, ModelState);
			if (!TryValidateModel(itemUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(itemUpdateDto, item);
			_unitOfWork.ItemRepository.Update(item);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// DELETE api/items/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var item = _unitOfWork.ItemRepository.GetSingle(id);
			if (item == null)
				return NotFound();
			_unitOfWork.ItemRepository.Delete(item);
			_unitOfWork.SaveChanges();
			return NoContent();
		}
	}
}