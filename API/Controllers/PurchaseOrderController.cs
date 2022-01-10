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
			UpdateItemStock(purchaseOrderModel.PurchaseOrderLines, purchaseOrderModel.DocumentState);
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
			if (purchaseOrder.DocumentState == (int)PurchaseOrder.PurchaseOrderState.Received)
				return BadRequest(new { title = "Erreur", errors = "Commande déjà réceptionnée, impossible de modifier." });
			_mapper.Map(purchaseOrderUpdateDto, purchaseOrder);
			_unitOfWork.PurchaseOrderRepository.Update(purchaseOrder);
			try
			{
				UpdatePurchaseOrderLines(purchaseOrderUpdateDto.PurchaseOrderLines, id, purchaseOrder.DocumentState);
				_unitOfWork.SaveChanges();
			}
			catch (Exception e)
			{
				return BadRequest(new {title = "Database error", errors = e.InnerException.Message });
			}
			return NoContent();
		}

		private void UpdatePurchaseOrderLines(IEnumerable<PurchaseOrderLineUpdateDto> purchaseOrderLineDtos, int purchaseOrderId, int state)
		{
			PurchaseOrderLine line;
			PurchaseOrderLineUpdateDto line2;
			int i;
			List<PurchaseOrderLine> purchaseOrderLines = (List<PurchaseOrderLine>)(_unitOfWork.PurchaseOrderLineRepository.FindBy(purchaseOrderLine => purchaseOrderLine.PurchaseOrderId == purchaseOrderId).OrderBy(line => line.LineOrder))?.ToList();
			purchaseOrderLineDtos = (List<PurchaseOrderLineUpdateDto>)purchaseOrderLineDtos.OrderBy(line => line.LineOrder)?.ToList();
			if (purchaseOrderLineDtos == null)
				purchaseOrderLineDtos = new List<PurchaseOrderLineUpdateDto>();
			if (purchaseOrderLines == null)
				purchaseOrderLines = new List<PurchaseOrderLine>();
			RemoveItemStock(purchaseOrderLines, state);

			for (i = 0; i < purchaseOrderLineDtos.Count() && i < purchaseOrderLines.Count(); ++i)
			{
				line = purchaseOrderLines.ElementAt(i);
				line2 = purchaseOrderLineDtos.ElementAt(i);

				_mapper.Map(purchaseOrderLineDtos.ElementAt(i), purchaseOrderLines.ElementAt(i));
				purchaseOrderLines.ElementAt(i).LineOrder = i;
			}
			if (i < purchaseOrderLineDtos.Count())
			{
				for (; i < purchaseOrderLineDtos.Count(); ++i)
				{
					line = _mapper.Map<PurchaseOrderLine>(purchaseOrderLineDtos.ElementAt(i));
					line.PurchaseOrderId = purchaseOrderId;
					line.LineOrder = i;
					line.CreatedUser = purchaseOrderLineDtos.ElementAt(i).ModifiedUser;
					_unitOfWork.PurchaseOrderLineRepository.Add(line);
					((List<PurchaseOrderLine>)purchaseOrderLines).Add(line);
				}
			}
			else if (i < purchaseOrderLines.Count())
			{
				while (i < purchaseOrderLines.Count())
				{
					_unitOfWork.PurchaseOrderLineRepository.Delete(purchaseOrderLines.ElementAt(i));
					((List<PurchaseOrderLine>)purchaseOrderLines).RemoveAt(i);
				}
			}
			UpdateItemStock(purchaseOrderLines, state);
		}

		// PATCH api/purchaseOrders/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<PurchaseOrderUpdateDto> patchDocument)
		{
			// TODO check if infos are valid
			var purchaseOrder = _unitOfWork.PurchaseOrderRepository.GetSingle(id);
			if (purchaseOrder == null)
				return NotFound();
			if (purchaseOrder.DocumentState == (int)PurchaseOrder.PurchaseOrderState.Received)
				return BadRequest(new { title = "Erreur", errors = "Commande déjà réceptionnée, impossible de modifier." });
			RemoveItemStock(purchaseOrder.PurchaseOrderLines, purchaseOrder.DocumentState);
			var purchaseOrderUpdateDto = _mapper.Map<PurchaseOrderUpdateDto>(purchaseOrder);
			patchDocument.ApplyTo(purchaseOrderUpdateDto, ModelState);
			if (!TryValidateModel(purchaseOrderUpdateDto))
				return ValidationProblem(ModelState);
			_mapper.Map(purchaseOrderUpdateDto, purchaseOrder);
			_unitOfWork.PurchaseOrderRepository.Update(purchaseOrder);
			UpdateItemStock(purchaseOrder.PurchaseOrderLines, purchaseOrder.DocumentState);
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
			if (purchaseOrder.DocumentState == (int)PurchaseOrder.PurchaseOrderState.Received)
				return BadRequest(new { title = "Erreur", errors = "Commande déjà réceptionnée, impossible de supprimer." });
			_unitOfWork.PurchaseOrderRepository.Delete(purchaseOrder);
			try
			{
				List<PurchaseOrderLine> purchaseOrderLines = (List<PurchaseOrderLine>)(_unitOfWork.PurchaseOrderLineRepository.FindBy(orderLine => orderLine.PurchaseOrderId == id).OrderBy(line => line.LineOrder))?.ToList();
				RemoveItemStock(purchaseOrderLines, purchaseOrder.DocumentState);
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
				item.VirtualStock += line.Quantity;
				if (state == (int)Order.OrderState.Delivered)
					item.RealStock += line.Quantity;
				_unitOfWork.ItemRepository.Update(item);
			}
		}
		private void RemoveItemStock(IEnumerable<PurchaseOrderLine> orderLines, int state)
		{
			foreach (PurchaseOrderLine line in orderLines)
			{
				if (line.ItemId == null || line.Quantity <= 0) continue;
				var item = _unitOfWork.ItemRepository.GetSingle((int)line.ItemId);
				item.VirtualStock -= line.Quantity;
				if (state == (int)PurchaseOrder.PurchaseOrderState.Received)
					item.RealStock -= line.Quantity;
				_unitOfWork.ItemRepository.Update(item);
			}
		}

	}
}