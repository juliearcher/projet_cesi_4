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
	[Route("api/purchaseOrders")]
	[ApiController]
	public class PurchaseOrderController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public PurchaseOrderController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET api/purchaseOrders
		[HttpGet]
		public ActionResult<IEnumerable<PurchaseOrderReadDto>> GetAllPurchaseOrders()
		{
			var purchaseOrderList = _unitOfWork.PurchaseOrderRepository.GetAll();
			return Ok(_mapper.Map<IEnumerable<PurchaseOrderReadDto>>(purchaseOrderList));
		}

		// GET api/purchaseOrders/{id}
		[HttpGet("{id}", Name = "GetPurchaseOrderById")]
		public ActionResult<IEnumerable<PurchaseOrderReadDto>> GetPurchaseOrderById(int id)
		{
			var purchaseOrder = _unitOfWork.PurchaseOrderRepository.GetSingle(item => item.Id == id, item => item.PurchaseOrderLines);
			return purchaseOrder != null ? Ok(_mapper.Map<PurchaseOrderReadDto>(purchaseOrder)) : NotFound();
		}

		//POST api/purchaseOrders
		[HttpPost]
		public ActionResult<PurchaseOrderReadDto> CreatePurchaseOrder(PurchaseOrderCreateDto purchaseOrderCreateDto)
		{
			// TODO check if infos are valid
			var purchaseOrderModel = _mapper.Map<PurchaseOrder>(purchaseOrderCreateDto);
			_unitOfWork.PurchaseOrderRepository.Add(purchaseOrderModel);
			RemoveItemStock(purchaseOrderModel.PurchaseOrderLines, purchaseOrderModel.DocumentState);
			try
			{
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
			var purchaseOrderReadDto = _mapper.Map<PurchaseOrderReadDto>(purchaseOrderModel);
			return CreatedAtRoute(nameof(GetPurchaseOrderById), new { Id = purchaseOrderReadDto.Id }, purchaseOrderReadDto);
		}

		// PUT api/purchaseOrders/{id}
		[HttpPut("{id}")]
		public ActionResult UpdatePurchaseOrder(int id, PurchaseOrderUpdateDto purchaseOrderUpdateDto)
		{
			// TODO check if infos are valid
			var purchaseOrder = _unitOfWork.PurchaseOrderRepository.GetSingle(id);
			if (purchaseOrder == null)
				return NotFound();
			UpdateItemStock(purchaseOrder.PurchaseOrderLines, purchaseOrder.DocumentState);
			_mapper.Map(purchaseOrderUpdateDto, purchaseOrder);
			_unitOfWork.PurchaseOrderRepository.Update(purchaseOrder);
			RemoveItemStock(purchaseOrder.PurchaseOrderLines, purchaseOrder.DocumentState);
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

		// PATCH api/purchaseOrders/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<PurchaseOrderUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var purchaseOrder = _unitOfWork.PurchaseOrderRepository.GetSingle(id);
			if (purchaseOrder == null)
				return NotFound();
			UpdateItemStock(purchaseOrder.PurchaseOrderLines, purchaseOrder.DocumentState);
			var purchaseOrderUpdateDto = _mapper.Map<PurchaseOrderUpdateDto>(purchaseOrder);
			patchDocument.ApplyTo(purchaseOrderUpdateDto, ModelState);
			if (!TryValidateModel(purchaseOrderUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(purchaseOrderUpdateDto, purchaseOrder);
			_unitOfWork.PurchaseOrderRepository.Update(purchaseOrder);
			RemoveItemStock(purchaseOrder.PurchaseOrderLines, purchaseOrder.DocumentState);
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

		// DELETE api/purchaseOrders/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// TODO check foreign keys
			var purchaseOrder = _unitOfWork.PurchaseOrderRepository.GetSingle(id);
			if (purchaseOrder == null)
				return NotFound();
			_unitOfWork.PurchaseOrderRepository.Delete(purchaseOrder);
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
		private void UpdateItemStock(IEnumerable<PurchaseOrderLine> orderLines, int state)
		{
			foreach (PurchaseOrderLine line in orderLines)
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
		private void RemoveItemStock(IEnumerable<PurchaseOrderLine> orderLines, int state)
		{
			foreach (PurchaseOrderLine line in orderLines)
			{
				if (line.ItemId == null || line.Quantity <= 0) continue;
				var item = _unitOfWork.ItemRepository.GetSingle((int)line.ItemId);
				if (state == (int)PurchaseOrder.PurchaseOrderState.Received)
					item.RealStock -= line.Quantity;
				else
					item.VirtualStock -= line.Quantity;
				_unitOfWork.ItemRepository.Update(item);
			}
		}

	}
}