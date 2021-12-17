using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class CustomerTabViewModelFactory : IViewModelTabFactory<CustomerTabViewModel>
	{
		private IViewModelListFactory<CustomerListViewModel> _customerListViewModelFactory;

		public CustomerTabViewModelFactory(IViewModelListFactory<CustomerListViewModel> customerListViewModelFactory)
		{
			_customerListViewModelFactory = customerListViewModelFactory;
		}

		public CustomerTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new CustomerTabViewModel(_customerListViewModelFactory.CreateViewModel(factory));
		}
	}
}
