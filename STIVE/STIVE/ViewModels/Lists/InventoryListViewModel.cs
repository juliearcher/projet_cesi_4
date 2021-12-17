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
	public class InventoryListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((Inventory)e).DocumentNumber.ToLower().Contains(_searchFilter);


		public InventoryListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.InventoryService.GetAllInventories().ContinueWith(task =>
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
			await _apiServicesCollection.InventoryService.DeleteInventory(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}
