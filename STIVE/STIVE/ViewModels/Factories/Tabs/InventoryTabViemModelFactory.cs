using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class InventoryTabViewModelFactory : IViewModelTabFactory<InventoryTabViewModel>
	{
		private IViewModelListFactory<InventoryListViewModel> _inventoryListViewModelFactory;

		public InventoryTabViewModelFactory(IViewModelListFactory<InventoryListViewModel> inventoryListViewModelFactory)
		{
			_inventoryListViewModelFactory = inventoryListViewModelFactory;
		}

		public InventoryTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new InventoryTabViewModel(_inventoryListViewModelFactory.CreateViewModel(factory));
		}
	}
}
