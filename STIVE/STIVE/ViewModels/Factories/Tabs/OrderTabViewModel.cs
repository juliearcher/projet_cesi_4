using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class OrderTabViewModelFactory : IViewModelTabFactory<OrderTabViewModel>
	{
		private IViewModelListFactory<OrderListViewModel> _orderListViewModelFactory;

		public OrderTabViewModelFactory(IViewModelListFactory<OrderListViewModel> orderListViewModelFactory)
		{
			_orderListViewModelFactory = orderListViewModelFactory;
		}

		public OrderTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new OrderTabViewModel(_orderListViewModelFactory.CreateViewModel(factory));
		}
	}
}
