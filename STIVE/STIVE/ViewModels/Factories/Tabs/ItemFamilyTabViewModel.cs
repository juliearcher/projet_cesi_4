using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemFamilyTabViewModelFactory : IViewModelTabFactory<ItemFamilyTabViewModel>
	{
		public ItemFamilyTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new ItemFamilyTabViewModel();
		}
	}
}
