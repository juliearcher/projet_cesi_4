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
	[Route("api/itemFamilies")]
	[ApiController]
	public class ItemFamilyController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ItemFamilyController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/itemFamilies
		[HttpGet]
		public ActionResult<IEnumerable<ItemFamilyReadDto>> GetAllItemFamilies()
		{
			var itemFamilyList = _unitOfWork.ItemFamilyRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<ItemFamilyReadDto>>(itemFamilyList));
		}

		// GET api/itemFamilies/{id}
		[HttpGet("{id}", Name = "GetItemFamilyById")]
		public ActionResult<IEnumerable<ItemFamilyReadDto>> GetItemFamilyById(int id)
		{
			var itemFamily = _unitOfWork.ItemFamilyRepository.GetSingle(id);
			return itemFamily != null ? Ok(_mapper.Map<ItemFamilyReadDto>(itemFamily)) : NotFound();
		}

		//POST api/itemFamilies
		[HttpPost]
		public ActionResult<ItemFamilyReadDto> CreateItemFamily(ItemFamilyCreateDto itemFamilyCreateDto)
		{
			// TODO check if infos are valid
			var itemFamilyModel = _mapper.Map<ItemFamily>(itemFamilyCreateDto);
			_unitOfWork.ItemFamilyRepository.Add(itemFamilyModel);
			_unitOfWork.SaveChanges();
			var itemFamilyReadDto = _mapper.Map<ItemFamilyReadDto>(itemFamilyModel);
			return CreatedAtRoute(nameof(GetItemFamilyById), new { Id = itemFamilyReadDto.Id }, itemFamilyReadDto);
		}

		// PUT api/itemFamilies/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateItemFamily(int id, ItemFamilyUpdateDto itemFamilyUpdateDto)
		{
			// TODO check if infos are valid
			var itemFamily = _unitOfWork.ItemFamilyRepository.GetSingle(id);
			if (itemFamily == null)
				return NotFound();
			_mapper.Map(itemFamilyUpdateDto, itemFamily);
			_unitOfWork.ItemFamilyRepository.Update(itemFamily);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// PATCH api/itemFamilies/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<ItemFamilyUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var itemFamily = _unitOfWork.ItemFamilyRepository.GetSingle(id);
			if (itemFamily == null)
				return NotFound();
			var itemFamilyUpdateDto = _mapper.Map<ItemFamilyUpdateDto>(itemFamily);
			patchDocument.ApplyTo(itemFamilyUpdateDto, ModelState);
			if (!TryValidateModel(itemFamilyUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(itemFamilyUpdateDto, itemFamily);
			_unitOfWork.ItemFamilyRepository.Update(itemFamily);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// DELETE api/itemFamilies/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var itemFamily = _unitOfWork.ItemFamilyRepository.GetSingle(id);
			if (itemFamily == null)
				return NotFound();
			_unitOfWork.ItemFamilyRepository.Delete(itemFamily);
			_unitOfWork.SaveChanges();
			return NoContent();
		}
	}
}