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
	public class PurchaseOrderListViewModel : ListViewModelBase
	{
		protected override Func<ApiModelBase, bool> Predicate => e => ((PurchaseOrder)e).DocumentNumber.ToLower().Contains(_searchFilter);


		public PurchaseOrderListViewModel(IApiServicesCollection apiServicesCollection, IViewModelAbstractFactory viewModelFactory)
		{
			_apiServicesCollection = apiServicesCollection;
			ViewModelFactory = viewModelFactory;
			LoadList();
		}

		public override void LoadList()
		{
			_apiServicesCollection.PurchaseOrderService.GetAllPurchaseOrders().ContinueWith(task =>
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
			await _apiServicesCollection.PurchaseOrderService.DeletePurchaseOrder(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}
