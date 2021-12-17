using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class SupplierTabViewModelFactory : IViewModelTabFactory<SupplierTabViewModel>
	{
		private IViewModelListFactory<SupplierListViewModel> _supplierListViewModelFactory;

		public SupplierTabViewModelFactory(IViewModelListFactory<SupplierListViewModel> supplierListViewModelFactory)
		{
			_supplierListViewModelFactory = supplierListViewModelFactory;
		}

		public SupplierTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new SupplierTabViewModel(_supplierListViewModelFactory.CreateViewModel(factory));
		}
	}
}
