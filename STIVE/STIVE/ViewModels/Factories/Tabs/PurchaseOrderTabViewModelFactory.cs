using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class PurchaseOrderTabViewModelFactory : IViewModelTabFactory<PurchaseOrderTabViewModel>
	{
		private IViewModelListFactory<PurchaseOrderListViewModel> _purchaseOrderListViewModelFactory;

		public PurchaseOrderTabViewModelFactory(IViewModelListFactory<PurchaseOrderListViewModel> purchaseOrderListViewModelFactory)
		{
			_purchaseOrderListViewModelFactory = purchaseOrderListViewModelFactory;
		}

		public PurchaseOrderTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new PurchaseOrderTabViewModel(_purchaseOrderListViewModelFactory.CreateViewModel(factory));
		}
	}
}
