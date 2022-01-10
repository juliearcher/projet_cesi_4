using API.Dtos;
using API.Models;
using AutoMapper;
using System.Collections.Generic;

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
			CreateMap<OrderUpdateDto, Order>().ForMember(elem => elem.OrderLines, opt => opt.Ignore());
			// Order to OrderUpdateDto
			// For PATCH
			CreateMap<Order, OrderUpdateDto>();
		}
	}
}