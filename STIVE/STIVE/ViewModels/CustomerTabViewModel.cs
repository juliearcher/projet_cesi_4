using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class CustomerTabViewModel : TabViewModelBase
	{
		public CustomerListViewModel CustomerListViewModel { get; set; }

		public CustomerTabViewModel(CustomerListViewModel customerListViewModel)
		{
			CustomerListViewModel = customerListViewModel;
		}
	}
}
