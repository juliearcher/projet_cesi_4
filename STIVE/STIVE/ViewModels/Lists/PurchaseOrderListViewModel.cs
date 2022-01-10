using STIVE.PrepAPI;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using STIVE.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public class PurchaseOrderListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((PurchaseOrder)e).DocumentNumber.ToLower().Contains(_searchFilter);


		public PurchaseOrderListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.PurchaseOrderService.GetAllPurchaseOrders().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					_initialList = task.Result;
					ElementsList = _initialList;
				}
			});
		}

		public async override Task DeleteSelectedItem()
		{
			await _apiServicesCollection.PurchaseOrderService.DeletePurchaseOrder(SelectedItem == null ? 0 : SelectedItem.Id);
		}
		public async Task DeliverPurchaseOrder()
		{
			await _apiServicesCollection.PurchaseOrderService.SetPurchaseOrderToReceived(SelectedItem == null ? 0 : SelectedItem.Id);
		}

		public ICommand SetCommandToDelivered => new SetCommandToDeliveredCommand(this);

		internal class SetCommandToDeliveredCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			private readonly PurchaseOrderListViewModel _vm;

			public SetCommandToDeliveredCommand(PurchaseOrderListViewModel vm)
			{
				_vm = vm;
			}

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public async void Execute(object parameter)
			{
				if (_vm.SelectedItem == null)
					return;
				PurchaseOrder order = _vm.SelectedItem as PurchaseOrder;
				if (order?.DocumentState == (int)IPurchaseOrder.PurchaseOrderState.Received)
				{
					MessageBox.Show("Cette commande est déjà reçue");
					return;
				}
				try
				{
					await _vm.DeliverPurchaseOrder();
					MessageBox.Show("Commande reçue");
					((PurchaseOrder)_vm.SelectedItem).DocumentState = (int)IPurchaseOrder.PurchaseOrderState.Received;
				}
				catch (ApiException e)
				{
					MessageBox.Show(e.Message, e.Title);
				}
			}
		}
	}
}
