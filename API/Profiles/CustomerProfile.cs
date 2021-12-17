using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			// Customer to CustomerReadDto
			CreateMap<Customer, CustomerReadDto>();
			// CustomerCreateDto to Customer
			CreateMap<CustomerCreateDto, Customer>();
			// CustomerUpdateDto to Customer
			// For PUT and PATCH
			CreateMap<CustomerUpdateDto, Customer>();
			// Customer to CustomerUpdateDto
			// For PATCH
			CreateMap<Customer, CustomerUpdateDto>();
		}
	}
}