using AutoMapper;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemFormViewModelFactory : IViewModelFormFactory<ItemFormViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;
		private readonly IMapper _mapper;

		public ItemFormViewModelFactory(IApiServicesCollection apiServicesCollection, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			_mapper = mapper;
		}

		public ItemFormViewModel CreateViewModel(ListViewModelBase viewModelBase, ApiModelBase elem)
		{
			return new ItemFormViewModel(_apiServicesCollection, viewModelBase, elem, _mapper);
		}
	}
}
