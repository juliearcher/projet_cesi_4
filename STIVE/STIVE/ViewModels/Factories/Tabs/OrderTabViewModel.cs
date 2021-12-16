using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class OrderTabViewModelFactory : IViewModelTabFactory<OrderTabViewModel>
	{
		public OrderTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new OrderTabViewModel();
		}
	}
}
