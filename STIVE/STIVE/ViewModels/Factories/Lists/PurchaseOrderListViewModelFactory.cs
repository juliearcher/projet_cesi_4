using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class PurchaseOrderListViewModelFactory : IViewModelListFactory<PurchaseOrderListViewModel>
	{
		private readonly IApiServicesCollection _apiServicesCollection;

		public PurchaseOrderListViewModelFactory(IApiServicesCollection apiServicesCollection)
		{
			_apiServicesCollection = apiServicesCollection;
		}

		public PurchaseOrderListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new PurchaseOrderListViewModel(_apiServicesCollection, factory);
		}
	}
}
