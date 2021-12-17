using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class OrderTabViewModel : TabViewModelBase
	{
		public OrderListViewModel OrderListViewModel { get; set; }

		public OrderTabViewModel(OrderListViewModel orderListViewModel)
		{
			OrderListViewModel = orderListViewModel;
		}
	}
}
