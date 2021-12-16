﻿using AutoMapper;
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
			CreateMap<ApiModelBase, DataErrorModelBase>();
			CreateMap<Customer, CustomerDataError>();
		}
	}
}
