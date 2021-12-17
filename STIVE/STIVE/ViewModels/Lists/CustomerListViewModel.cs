using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using STIVE.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class CustomerListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((Customer)e).Code.ToLower().Contains(_searchFilter);


		public CustomerListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.CustomerService.GetAllCustomers().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					_initialList = task.Result;
					ElementsList = _initialList;
				}
			});
		}

		public async override Task DeleteSelectedItem()
		{
			await _apiServicesCollection.CustomerService.DeleteCustomer(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}
