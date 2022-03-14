using AutoMapper;
using STIVE.Models;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class ItemFormViewModel : FormViewModelBase
	{
		private IEnumerable<IItemFamily> _itemFamilyList;
		public IEnumerable<IItemFamily> ItemFamilyList
		{
			get
			{
				return _itemFamilyList;
			}
			set
			{
				_itemFamilyList = value;
				OnPropertyChanged(nameof(ItemFamilyList));
			}
		}

		private IEnumerable<ISupplier> _supplierList;
		public IEnumerable<ISupplier> SupplierList
		{
			get
			{
				return _supplierList;
			}
			set
			{
				_supplierList = value;
				OnPropertyChanged(nameof(SupplierList));
			}
		}

		public ItemFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_oldElem = elem ?? new Item();
			_mode = elem == null ? FormViewModelBase.EditMode.CREATE : FormViewModelBase.EditMode.UPDATE;
			NewElem = new ItemDataError((Item)_oldElem);
			LoadLists();
		}

		private void LoadLists()
		{
			_apiServicesCollection.ItemFamilyService.GetAllItemFamilies().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					ItemFamilyList = task.Result;
				}
			});
			_apiServicesCollection.SupplierService.GetAllSuppliers().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					SupplierList = task.Result;
				}
			});
		}

		public override bool IsValid()
		{
			((ItemDataError)NewElem).CreatedUser = "admin";
			((ItemDataError)NewElem).ModifiedUser = "admin";
			return true;
		}

		public async override Task SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				Item newItem = await _apiServicesCollection.ItemService.CreateItem(_mapper.Map<Item>(NewElem));
				_oldElem = newItem;
				NewElem = new ItemDataError(newItem);
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.ItemService.UpdateItem(_mapper.Map<Item>(NewElem));
			}
		}
	}
}
