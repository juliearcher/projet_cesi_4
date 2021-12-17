using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
	public class SupplierProfile : Profile
	{
		public SupplierProfile()
		{
			// Supplier to SupplierReadDto
			CreateMap<Supplier, SupplierReadDto>();
			// SupplierCreateDto to Supplier
			CreateMap<SupplierCreateDto, Supplier>();
			// SupplierUpdateDto to Supplier
			// For PUT and PATCH
			CreateMap<SupplierUpdateDto, Supplier>();
			// Supplier to SupplierUpdateDto
			// For PATCH
			CreateMap<Supplier, SupplierUpdateDto>();
		}
	}
}