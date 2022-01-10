using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class InventoryProfile : Profile
	{
		public InventoryProfile()
		{
			// Inventory to InventoryReadDto
			CreateMap<Inventory, InventoryReadDto>();
			// InventoryCreateDto to Inventory
			CreateMap<InventoryCreateDto, Inventory>();
			// InventoryUpdateDto to Inventory
			// For PUT and PATCH
			CreateMap<InventoryUpdateDto, Inventory>().ForMember(elem => elem.InventoryLines, opt => opt.Ignore()); ;
			// Inventory to InventoryUpdateDto
			// For PATCH
			CreateMap<Inventory, InventoryUpdateDto>();
		}
	}
}