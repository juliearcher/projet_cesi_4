using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemFamilyTabViewModelFactory : IViewModelTabFactory<ItemFamilyTabViewModel>
	{
		private IViewModelListFactory<ItemFamilyListViewModel> _itemFamilyListViewModelFactory;

		public ItemFamilyTabViewModelFactory(IViewModelListFactory<ItemFamilyListViewModel> itemFamilyListViewModelFactory)
		{
			_itemFamilyListViewModelFactory = itemFamilyListViewModelFactory;
		}

		public ItemFamilyTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new ItemFamilyTabViewModel(_itemFamilyListViewModelFactory.CreateViewModel(factory));
		}
	}
}
