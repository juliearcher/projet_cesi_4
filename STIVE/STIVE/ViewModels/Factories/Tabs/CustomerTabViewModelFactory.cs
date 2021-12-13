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
		public CustomerTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new CustomerTabViewModel();
		}
	}
}
