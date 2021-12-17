using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class ItemTabViewModel : TabViewModelBase
	{
		public ItemListViewModel ItemListViewModel { get; set; }

		public ItemTabViewModel(ItemListViewModel itemListViewModel)
		{
			ItemListViewModel = itemListViewModel;
		}
	}
}
