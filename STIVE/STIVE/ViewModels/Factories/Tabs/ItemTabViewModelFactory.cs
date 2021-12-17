using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public class ItemTabViewModelFactory : IViewModelTabFactory<ItemTabViewModel>
	{
		private IViewModelListFactory<ItemListViewModel> _itemListViewModelFactory;

		public ItemTabViewModelFactory(IViewModelListFactory<ItemListViewModel> itemListViewModelFactory)
		{
			_itemListViewModelFactory = itemListViewModelFactory;
		}

		public ItemTabViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new ItemTabViewModel(_itemListViewModelFactory.CreateViewModel(factory));
		}
	}
}
