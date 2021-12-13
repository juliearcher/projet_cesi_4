using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class SupplierTabViewModelFactory : IViewModelTabFactory<SupplierTabViewModel>
	{
		public SupplierTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new SupplierTabViewModel();
		}
	}
}
