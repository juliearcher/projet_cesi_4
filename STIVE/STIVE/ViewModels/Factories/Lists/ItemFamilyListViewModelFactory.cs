using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemFamilyListViewModelFactory : IViewModelListFactory<ItemFamilyListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public ItemFamilyListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public ItemFamilyListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new ItemFamilyListViewModel(_apiServicesCollection, factory);
		}
	}
}
