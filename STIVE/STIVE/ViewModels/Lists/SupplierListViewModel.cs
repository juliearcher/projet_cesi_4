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
	public class SupplierListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((Supplier)e).Code.ToLower().Contains(_searchFilter);


		public SupplierListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.SupplierService.GetAllSuppliers().ContinueWith(task =>
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
			await _apiServicesCollection.SupplierService.DeleteSupplier(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}
