using AutoMapper;
using STIVE.Models;
using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Profiles
{
	public class DataErrorProfile : Profile
	{
		public DataErrorProfile()
		{
			CreateMap<ApiModelBase, DataErrorModelBase>().ReverseMap();
			CreateMap<Customer, CustomerDataError>().ReverseMap();
			CreateMap<Order, OrderDataError>().ReverseMap();
			CreateMap<OrderLine, OrderLineDataError>().ReverseMap();
			CreateMap<PurchaseOrder, PurchaseOrderDataError>().ReverseMap();
			CreateMap<PurchaseOrderLine, PurchaseOrderLineDataError>().ReverseMap();
		}
	}
}
