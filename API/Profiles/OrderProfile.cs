using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
			// Order to OrderReadDto
			CreateMap<Order, OrderReadDto>();
			// OrderCreateDto to Order
			CreateMap<OrderCreateDto, Order>();
			// OrderUpdateDto to Order
			// For PUT and PATCH
			CreateMap<OrderUpdateDto, Order>();
			// Order to OrderUpdateDto
			// For PATCH
			CreateMap<Order, OrderUpdateDto>();
		}
	}
}