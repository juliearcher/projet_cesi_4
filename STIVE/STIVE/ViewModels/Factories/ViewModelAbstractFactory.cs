using STIVE.Navigators;
using STIVE.PrepAPI.Models;
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
		private IViewModelTabFactory<CustomerTabViewModel> _customerTabViewModel;
		private IViewModelTabFactory<SupplierTabViewModel> _supplierTabViewModel;

		private IViewModelFormFactory<CustomerFormViewModel> _customerFormView;

		public ViewModelAbstractFactory(IViewModelTabFactory<CustomerTabViewModel> customerTabViewModel, IViewModelTabFactory<SupplierTabViewModel> supplierTabViewModel, IViewModelFormFactory<CustomerFormViewModel> customerFormView)
		{
			_customerTabViewModel = customerTabViewModel;
			_supplierTabViewModel = supplierTabViewModel;
			_customerFormView = customerFormView;
		}

		public FormViewModelBase CreateFormViewModel(ListViewModelBase viewmodel, FormViewType viewType, ApiModelBase elem)
		{
			switch (viewType)
			{
				case FormViewType.CustomerForm:
					return _customerFormView.CreateViewModel(viewmodel, elem);
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
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
		}
	}
}
