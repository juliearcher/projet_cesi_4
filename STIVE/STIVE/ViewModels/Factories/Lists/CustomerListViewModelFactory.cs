using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class CustomerListViewModelFactory : IViewModelListFactory<CustomerListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public CustomerListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public CustomerListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new CustomerListViewModel(_apiServicesCollection, factory);
		}
	}
}
