using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class OrderListViewModelFactory : IViewModelListFactory<OrderListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public OrderListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public OrderListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new OrderListViewModel(_apiServicesCollection, factory);
		}
	}
}
