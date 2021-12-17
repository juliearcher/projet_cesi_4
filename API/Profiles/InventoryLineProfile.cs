using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class InventoryLineProfile : Profile
	{
		public InventoryLineProfile()
		{
			// InventoryLine to InventoryLineReadDto
			CreateMap<InventoryLine, InventoryLineReadDto>(); 
			// InventoryLineCreateDto to InventoryLine
			CreateMap<InventoryLineCreateDto, InventoryLine>();
			// InventoryLineUpdateDto to InventoryLine
			// For PUT and PATCH
			CreateMap<InventoryLineUpdateDto, InventoryLine>();
			// InventoryLine to InventoryLineUpdateDto
			// For PATCH
			CreateMap<InventoryLine, InventoryLineUpdateDto>();
		}
	}
}