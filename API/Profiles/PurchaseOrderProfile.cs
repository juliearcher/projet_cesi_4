using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class PurchaseOrderProfile : Profile
	{
		public PurchaseOrderProfile()
		{
			// PurchaseOrder to PurchaseOrderReadDto
			CreateMap<PurchaseOrder, PurchaseOrderReadDto>();
			// PurchaseOrderCreateDto to PurchaseOrder
			CreateMap<PurchaseOrderCreateDto, PurchaseOrder>();
			// PurchaseOrderUpdateDto to PurchaseOrder
			// For PUT and PATCH
			CreateMap<PurchaseOrderUpdateDto, PurchaseOrder>().ForMember(elem => elem.PurchaseOrderLines, opt => opt.Ignore());
			// PurchaseOrder to PurchaseOrderUpdateDto
			// For PATCH
			CreateMap<PurchaseOrder, PurchaseOrderUpdateDto>();
		}
	}
}