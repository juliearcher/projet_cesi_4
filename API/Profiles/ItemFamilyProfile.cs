using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class ItemFamilyProfile : Profile
	{
		public ItemFamilyProfile()
		{
			// ItemFamily to ItemFamilyReadDto
			CreateMap<ItemFamily, ItemFamilyReadDto>();
			// ItemFamilyCreateDto to ItemFamily
			CreateMap<ItemFamilyCreateDto, ItemFamily>();
			// ItemFamilyUpdateDto to ItemFamily
			// For PUT and PATCH
			CreateMap<ItemFamilyUpdateDto, ItemFamily>();
			// ItemFamily to ItemFamilyUpdateDto
			// For PATCH
			CreateMap<ItemFamily, ItemFamilyUpdateDto>();
		}
	}
}