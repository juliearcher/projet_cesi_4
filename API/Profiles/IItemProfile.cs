using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class ItemProfile : Profile
	{
		public ItemProfile()
		{
			// Item to ItemReadDto
			CreateMap<Item, ItemReadDto>();
			// ItemCreateDto to Item
			CreateMap<ItemCreateDto, Item>();
			// ItemUpdateDto to Item
			// For PUT and PATCH
			CreateMap<ItemUpdateDto, Item>();
			// Item to ItemUpdateDto
			// For PATCH
			CreateMap<Item, ItemUpdateDto>();
		}
	}
}