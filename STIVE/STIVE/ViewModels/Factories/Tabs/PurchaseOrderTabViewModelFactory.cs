using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class PurchaseOrderTabViewModelFactory : IViewModelTabFactory<PurchaseOrderTabViewModel>
	{
		public PurchaseOrderTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new PurchaseOrderTabViewModel();
		}
	}
}
