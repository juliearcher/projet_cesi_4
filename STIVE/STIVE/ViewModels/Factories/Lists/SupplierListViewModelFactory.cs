using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class SupplierListViewModelFactory : IViewModelListFactory<SupplierListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public SupplierListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public SupplierListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new SupplierListViewModel(_apiServicesCollection, factory);
		}
	}
}
