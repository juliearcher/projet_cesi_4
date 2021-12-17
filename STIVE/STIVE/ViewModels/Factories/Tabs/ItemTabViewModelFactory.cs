using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemTabViewModelFactory : IViewModelTabFactory<ItemTabViewModel>
	{
		public ItemTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new ItemTabViewModel();
		}
	}
}
