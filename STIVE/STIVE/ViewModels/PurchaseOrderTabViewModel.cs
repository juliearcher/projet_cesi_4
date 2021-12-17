using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class PurchaseOrderTabViewModel : TabViewModelBase
	{
		public PurchaseOrderListViewModel PurchaseOrderListViewModel { get; set; }

		public PurchaseOrderTabViewModel(PurchaseOrderListViewModel purchaseOrderListViewModel)
		{
			PurchaseOrderListViewModel = purchaseOrderListViewModel;
		}
	}
}
