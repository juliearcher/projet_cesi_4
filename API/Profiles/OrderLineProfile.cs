using API.Dtos;
using API.Models;
using AutoMapper;
using System.Collections.Generic;

namespace API.Profiles
{
	public class OrderLineProfile : Profile
	{
		public OrderLineProfile()
		{
			// OrderLine to OrderLineReadDto
			CreateMap<OrderLine, OrderLineReadDto>();
			// OrderLineCreateDto to OrderLine
			CreateMap<OrderLineCreateDto, OrderLine>();
			// OrderLineUpdateDto to OrderLine
			// For PUT and PATCH
			CreateMap<OrderLineUpdateDto, OrderLine>();
			// OrderLine to OrderLineUpdateDto
			// For PATCH
			CreateMap<OrderLine, OrderLineUpdateDto>();
		}
	}
}