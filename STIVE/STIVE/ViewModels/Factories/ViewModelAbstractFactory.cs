using STIVE.Navigators;
using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ViewModelAbstractFactory : IViewModelAbstractFactory
	{
		IViewModelTabFactory<CustomerTabViewModel> _customerTabViewModel;
		IViewModelTabFactory<SupplierTabViewModel> _supplierTabViewModel;

		public ViewModelAbstractFactory(IViewModelTabFactory<CustomerTabViewModel> customerTabViewModel, IViewModelTabFactory<SupplierTabViewModel> supplierTabViewModel)
		{
			_customerTabViewModel = customerTabViewModel;
			_supplierTabViewModel = supplierTabViewModel;
		}

		public ViewModelBase CreateTabViewModel(ViewType viewType)
		{
			switch (viewType)
			{
				case ViewType.CustomerTab:
					return _customerTabViewModel.CreateViewModel(this);
				case ViewType.SupplierTab:
					return _supplierTabViewModel.CreateViewModel(this);
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
			throw new NotImplementedException();
		}
	}
}
