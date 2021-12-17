using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class ItemFamilyTabViewModel : TabViewModelBase
	{
		public ItemFamilyListViewModel ItemFamilyListViewModel { get; set; }

		public ItemFamilyTabViewModel(ItemFamilyListViewModel itemFamilyListViewModel)
		{
			ItemFamilyListViewModel = itemFamilyListViewModel;
		}
	}
}
