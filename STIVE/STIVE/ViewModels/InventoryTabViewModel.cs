using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class InventoryTabViewModel : TabViewModelBase
	{
		public InventoryListViewModel InventoryListViewModel { get; set; }

		public InventoryTabViewModel(InventoryListViewModel inventoryListViewModel)
		{
			InventoryListViewModel = inventoryListViewModel;
		}
	}
}
