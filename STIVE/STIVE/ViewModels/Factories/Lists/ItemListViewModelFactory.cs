using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemListViewModelFactory : IViewModelListFactory<ItemListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public ItemListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public ItemListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new ItemListViewModel(_apiServicesCollection, factory);
		}
	}
}
