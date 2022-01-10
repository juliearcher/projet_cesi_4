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
	public class OrderListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((Order)e).DocumentNumber.ToLower().Contains(_searchFilter);


		public OrderListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.OrderService.GetAllOrders().ContinueWith(task =>
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
			await _apiServicesCollection.OrderService.DeleteOrder(SelectedItem == null ? 0 : SelectedItem.Id);
		}

		public async Task DeliverOrder()
		{
			await _apiServicesCollection.OrderService.SetOrderToDelivered(SelectedItem == null ? 0 : SelectedItem.Id);
		}

		public ICommand SetCommandToDelivered => new SetCommandToDeliveredCommand(this);

		internal class SetCommandToDeliveredCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			private readonly OrderListViewModel _vm;

			public SetCommandToDeliveredCommand(OrderListViewModel vm)
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
				Order order = _vm.SelectedItem as Order;
				if (order?.DocumentState == (int)IOrder.OrderState.Delivered)
				{
					MessageBox.Show("Cette commande est déjà livrée");
					return;
				}
				try
				{
					await _vm.DeliverOrder();
					MessageBox.Show("Commande livrée");
					((Order)_vm.SelectedItem).DocumentState = (int)IOrder.OrderState.Delivered;
					_vm.LoadList();
				}
				catch (ApiException e)
				{
					MessageBox.Show(e.Message, e.Title);
				}
			}
		}
	}
}
