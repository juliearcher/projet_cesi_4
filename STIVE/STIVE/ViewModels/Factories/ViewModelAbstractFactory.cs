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
		private IViewModelTabFactory<InventoryTabViewModel> _inventoryTabViewModel;
		private IViewModelTabFactory<ItemTabViewModel> _itemTabViewModel;
		private IViewModelTabFactory<ItemFamilyTabViewModel> _itemFamilyTabViewModel;
		private IViewModelTabFactory<OrderTabViewModel> _orderTabViewModel;
		private IViewModelTabFactory<PurchaseOrderTabViewModel> _purchaseOrderTabViewModel;
		private IViewModelTabFactory<SupplierTabViewModel> _supplierTabViewModel;


		private IViewModelFormFactory<CustomerFormViewModel> _customerFormView;

		public ViewModelAbstractFactory(IViewModelTabFactory<CustomerTabViewModel> customerTabViewModel, IViewModelTabFactory<SupplierTabViewModel> supplierTabViewModel, IViewModelFormFactory<CustomerFormViewModel> customerFormView, IViewModelTabFactory<InventoryTabViewModel> inventoryTabViewModel, IViewModelTabFactory<ItemFamilyTabViewModel> itemFamilyTabViewModel, IViewModelTabFactory<OrderTabViewModel> orderTabViewModel, IViewModelTabFactory<PurchaseOrderTabViewModel> purchaseOrderTabViewModel, IViewModelTabFactory<ItemTabViewModel> itemTabViewModel)
		{
			_customerTabViewModel = customerTabViewModel;
			_supplierTabViewModel = supplierTabViewModel;
			_customerFormView = customerFormView;
			_inventoryTabViewModel = inventoryTabViewModel;
			_itemFamilyTabViewModel = itemFamilyTabViewModel;
			_orderTabViewModel = orderTabViewModel;
			_purchaseOrderTabViewModel = purchaseOrderTabViewModel;
			_itemTabViewModel = itemTabViewModel;
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
				case ViewType.InventoryTab:
					return _inventoryTabViewModel.CreateViewModel(this);
				case ViewType.ItemTab:
					return _itemTabViewModel.CreateViewModel(this);
				case ViewType.ItemFamilyTab:
					return _itemFamilyTabViewModel.CreateViewModel(this);
				case ViewType.OrderTab:
					return _orderTabViewModel.CreateViewModel(this);
				case ViewType.PurchaseOrderTab:
					return _purchaseOrderTabViewModel.CreateViewModel(this);
				case ViewType.SupplierTab:
					return _supplierTabViewModel.CreateViewModel(this);
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
		}
	}
}
