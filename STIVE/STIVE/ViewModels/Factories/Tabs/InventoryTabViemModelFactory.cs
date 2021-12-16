using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class InventoryTabViewModelFactory : IViewModelTabFactory<InventoryTabViewModel>
	{
		public InventoryTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new InventoryTabViewModel();
		}
	}
}
