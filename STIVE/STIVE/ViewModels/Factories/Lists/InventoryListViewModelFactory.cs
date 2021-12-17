using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class InventoryListViewModelFactory : IViewModelListFactory<InventoryListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public InventoryListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public InventoryListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new InventoryListViewModel(_apiServicesCollection, factory);
		}
	}
}
