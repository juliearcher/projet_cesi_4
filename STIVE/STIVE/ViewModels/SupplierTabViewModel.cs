using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class SupplierTabViewModel : TabViewModelBase
	{
		public SupplierListViewModel SupplierListViewModel { get; set; }

		public SupplierTabViewModel(SupplierListViewModel supplierListViewModel)
		{
			SupplierListViewModel = supplierListViewModel;
		}
	}
}
