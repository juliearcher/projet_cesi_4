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
	public class InventoryListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((Inventory)e).DocumentNumber.ToLower().Contains(_searchFilter);

		public InventoryListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.InventoryService.GetAllInventories().ContinueWith(task =>
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
			await _apiServicesCollection.InventoryService.DeleteInventory(SelectedItem == null ? 0 : SelectedItem.Id);
		}

		public async Task DeliverInventory()
		{
			await _apiServicesCollection.InventoryService.SetInventoryToValidated(SelectedItem == null ? 0 : SelectedItem.Id);
		}

		public ICommand SetInventoryToValidated => new SetInventoryToValidatedCommand(this);

		internal class SetInventoryToValidatedCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			private readonly InventoryListViewModel _vm;

			public SetInventoryToValidatedCommand(InventoryListViewModel vm)
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
				Inventory order = _vm.SelectedItem as Inventory;
				if (order?.DocumentState == (int)IInventory.InventoryState.Validated)
				{
					MessageBox.Show("Cet inventaire est déjà validé");
					return;
				}
				try
				{
					await _vm.DeliverInventory();
					MessageBox.Show("Inventaire validé");
					((Inventory)_vm.SelectedItem).DocumentState = (int)IInventory.InventoryState.Validated;
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