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
	[Route("api/suppliers")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SupplierController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/suppliers
		[HttpGet]
		public ActionResult<IEnumerable<SupplierReadDto>> GetAllSuppliers()
		{
			var supplierList = _unitOfWork.SupplierRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<SupplierReadDto>>(supplierList));
		}

		// GET api/suppliers/{id}
		[HttpGet("{id}", Name = "GetSupplierById")]
		public ActionResult<IEnumerable<SupplierReadDto>> GetSupplierById(int id)
		{
			var supplier = _unitOfWork.SupplierRepository.GetSingle(id);
			return supplier != null ? Ok(_mapper.Map<SupplierReadDto>(supplier)) : NotFound();
		}

		//POST api/suppliers
		[HttpPost]
		public ActionResult<SupplierReadDto> CreateSupplier(SupplierCreateDto supplierCreateDto)
		{
			// TODO check if infos are valid
			var supplierModel = _mapper.Map<Supplier>(supplierCreateDto);
			_unitOfWork.SupplierRepository.Add(supplierModel);
			_unitOfWork.SaveChanges();
			var supplierReadDto = _mapper.Map<SupplierReadDto>(supplierModel);
			return CreatedAtRoute(nameof(GetSupplierById), new { Id = supplierReadDto.Id }, supplierReadDto);
		}

		// PUT api/suppliers/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateSupplier(int id, SupplierUpdateDto supplierUpdateDto)
		{
			// TODO check if infos are valid
			var supplier = _unitOfWork.SupplierRepository.GetSingle(id);
			if (supplier == null)
				return NotFound();
			_mapper.Map(supplierUpdateDto, supplier);
			_unitOfWork.SupplierRepository.Update(supplier);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// PATCH api/suppliers/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<SupplierUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var supplier = _unitOfWork.SupplierRepository.GetSingle(id);
			if (supplier == null)
				return NotFound();
			var supplierUpdateDto = _mapper.Map<SupplierUpdateDto>(supplier);
			patchDocument.ApplyTo(supplierUpdateDto, ModelState);
			if (!TryValidateModel(supplierUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(supplierUpdateDto, supplier);
			_unitOfWork.SupplierRepository.Update(supplier);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// DELETE api/suppliers/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var supplier = _unitOfWork.SupplierRepository.GetSingle(id);
			if (supplier == null)
				return NotFound();
			_unitOfWork.SupplierRepository.Delete(supplier);
			_unitOfWork.SaveChanges();
			return NoContent();
		}
	}
}