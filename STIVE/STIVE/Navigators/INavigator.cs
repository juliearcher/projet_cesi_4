using STIVE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STIVE.Navigators
{
	public enum ViewType
	{
		CustomerTab,
		InventoryTab,
		ItemTab,
		ItemFamilyTab, 
		OrderTab,
		PurchaseOrderTab,
		SupplierTab
	};

	public enum FormViewType
	{
		CustomerForm,
		OrderForm,
		PurchaseOrderForm
	};

	public interface INavigator
	{
		ViewModelBase CurrentViewModel { get; set; }
		ICommand UpdateCurrentViewModelCommand { get; }

	}
}
