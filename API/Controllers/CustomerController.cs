using API.Configuration;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
	[Route("api/customers")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/customers
		[HttpGet]
		public ActionResult<IEnumerable<CustomerReadDto>> GetAllCustomers()
		{
			var customerList = _unitOfWork.CustomerRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerList));
		}

		// GET api/customers/{id}
		[HttpGet("{id}", Name = "GetCustomerById")]
		public ActionResult<IEnumerable<CustomerReadDto>> GetCustomerById(int id)
		{
			var customer = _unitOfWork.CustomerRepository.GetSingle(id);
			return customer != null ? Ok(_mapper.Map<CustomerReadDto>(customer)) : NotFound();
		}

		//POST api/customers
		[HttpPost]
		public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto customerCreateDto)
		{
			// TODO check if infos are valid
			var customerModel = _mapper.Map<Customer>(customerCreateDto);
			_unitOfWork.CustomerRepository.Add(customerModel);
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
			var customerReadDto = _mapper.Map<CustomerReadDto>(customerModel);
			return CreatedAtRoute(nameof(GetCustomerById), new { Id = customerReadDto.Id }, customerReadDto);
		}

		// PUT api/customers/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)
		{
			// TODO check if infos are valid
			var customer = _unitOfWork.CustomerRepository.GetSingle(id);
			if (customer == null)
				return NotFound();
			_mapper.Map(customerUpdateDto, customer);
			_unitOfWork.CustomerRepository.Update(customer);
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

		// PATCH api/customers/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CustomerUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var customer = _unitOfWork.CustomerRepository.GetSingle(id);
			if (customer == null)
				return NotFound();
			var customerUpdateDto = _mapper.Map<CustomerUpdateDto>(customer);
			patchDocument.ApplyTo(customerUpdateDto, ModelState);
			if (!TryValidateModel(customerUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(customerUpdateDto, customer);
			_unitOfWork.CustomerRepository.Update(customer);
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

		// DELETE api/customers/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var customer = _unitOfWork.CustomerRepository.GetSingle(id);
			if (customer == null)
				return NotFound();
			_unitOfWork.CustomerRepository.Delete(customer);
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
	}
}