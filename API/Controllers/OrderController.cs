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
	[Route("api/orders")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/orders
		[HttpGet]
		public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders()
		{
			var orderList = _unitOfWork.OrderRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orderList));
		}

		// GET api/orders/{id}
		[HttpGet("{id}", Name = "GetOrderById")]
		public ActionResult<IEnumerable<OrderReadDto>> GetOrderById(int id)
		{
			var order = _unitOfWork.OrderRepository.GetSingle(item => item.Id == id, item => item.OrderLines);
			return order != null ? Ok(_mapper.Map<OrderReadDto>(order)) : NotFound();
		}

		//POST api/orders
		[HttpPost]
		public ActionResult<OrderReadDto> CreateOrder(OrderCreateDto orderCreateDto)
		{
			// TODO check if infos are valid
			var orderModel = _mapper.Map<Order>(orderCreateDto);
			_unitOfWork.OrderRepository.Add(orderModel);
			_unitOfWork.SaveChanges();
			var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);
			return CreatedAtRoute(nameof(GetOrderById), new { Id = orderReadDto.Id }, orderReadDto);
		}

		// PUT api/orders/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateOrder(int id, OrderUpdateDto orderUpdateDto)
		{
			// TODO check if infos are valid
			var order = _unitOfWork.OrderRepository.GetSingle(id);
			if (order == null)
				return NotFound();
			_mapper.Map(orderUpdateDto, order);
			_unitOfWork.OrderRepository.Update(order);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// PATCH api/orders/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<OrderUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var order = _unitOfWork.OrderRepository.GetSingle(id);
			if (order == null)
				return NotFound();
			var orderUpdateDto = _mapper.Map<OrderUpdateDto>(order);
			patchDocument.ApplyTo(orderUpdateDto, ModelState);
			if (!TryValidateModel(orderUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(orderUpdateDto, order);
			_unitOfWork.OrderRepository.Update(order);
			_unitOfWork.SaveChanges();
			return NoContent();
		}

		// DELETE api/orders/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var order = _unitOfWork.OrderRepository.GetSingle(id);
			if (order == null)
				return NotFound();
			_unitOfWork.OrderRepository.Delete(order);
			_unitOfWork.SaveChanges();
			return NoContent();
		}
	}
}