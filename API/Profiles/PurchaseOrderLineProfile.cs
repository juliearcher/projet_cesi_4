using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class PurchaseOrderLineProfile : Profile
	{
		public PurchaseOrderLineProfile()
		{
			// PurchaseOrderLine to PurchaseOrderLineReadDto
			CreateMap<PurchaseOrderLine, PurchaseOrderLineReadDto>();
			// PurchaseOrderLineCreateDto to PurchaseOrderLine
			CreateMap<PurchaseOrderLineCreateDto, PurchaseOrderLine>();
			// PurchaseOrderLineUpdateDto to PurchaseOrderLine
			// For PUT and PATCH
			CreateMap<PurchaseOrderLineUpdateDto, PurchaseOrderLine>();
			// PurchaseOrderLine to PurchaseOrderLineUpdateDto
			// For PATCH
			CreateMap<PurchaseOrderLine, PurchaseOrderLineUpdateDto>();
		}
	}
}