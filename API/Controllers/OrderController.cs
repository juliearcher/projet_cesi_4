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
			UpdateItemStock(orderModel.OrderLines, orderModel.DocumentState);
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
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
			RemoveItemStock(order.OrderLines, order.DocumentState);
			_mapper.Map(orderUpdateDto, order);
			_unitOfWork.OrderRepository.Update(order);
			UpdateItemStock(order.OrderLines, order.DocumentState);
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new { title = "Database error", errors = e.InnerException.Message });
			}
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
			RemoveItemStock(order.OrderLines, order.DocumentState);
			var orderUpdateDto = _mapper.Map<OrderUpdateDto>(order);
			patchDocument.ApplyTo(orderUpdateDto, ModelState);
			if (!TryValidateModel(orderUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(orderUpdateDto, order);
			_unitOfWork.OrderRepository.Update(order);
			UpdateItemStock(order.OrderLines, order.DocumentState);
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

		// DELETE api/orders/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var order = _unitOfWork.OrderRepository.GetSingle(id);
			if (order == null)
				return NotFound();
			_unitOfWork.OrderRepository.Delete(order);
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

		private void UpdateItemStock(IEnumerable<OrderLine> orderLines, int state)
		{
			foreach (OrderLine line in orderLines)
			{
				if (line.ItemId == null || line.Quantity <= 0) continue;
				var item = _unitOfWork.ItemRepository.GetSingle((int)line.ItemId);
				if (state == (int)Order.OrderState.Delivered)
					item.RealStock += line.Quantity;
				else
					item.VirtualStock += line.Quantity;
				_unitOfWork.ItemRepository.Update(item);
			}
		}
		private void RemoveItemStock(IEnumerable<OrderLine> orderLines, int state)
		{
			foreach (OrderLine line in orderLines)
			{
				if (line.ItemId == null || line.Quantity <= 0) continue;
				var item = _unitOfWork.ItemRepository.GetSingle((int)line.ItemId);
				if (state == (int)Order.OrderState.Delivered)
					item.RealStock -= line.Quantity;
				else
					item.VirtualStock -= line.Quantity;
				_unitOfWork.ItemRepository.Update(item);
			}
		}
	}
}