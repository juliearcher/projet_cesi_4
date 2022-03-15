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
	public class ItemFamilyFormViewModel : FormViewModelBase
	{
		public ItemFamilyFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_oldElem = elem ?? new ItemFamily();
			_mode = elem == null ? FormViewModelBase.EditMode.CREATE : FormViewModelBase.EditMode.UPDATE;
			NewElem = new ItemFamilyDataError((ItemFamily)_oldElem);
		}

		public override bool IsValid()
		{
			((ItemFamilyDataError)NewElem).CreatedUser = "admin";
			((ItemFamilyDataError)NewElem).ModifiedUser = "admin";
			return true;
		}

		public async override Task SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				ItemFamily newItemFamily = await _apiServicesCollection.ItemFamilyService.CreateItemFamily(_mapper.Map<ItemFamily>(NewElem));
				_oldElem = newItemFamily;
				NewElem = new ItemFamilyDataError(newItemFamily);
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.ItemFamilyService.UpdateItemFamily(_mapper.Map<ItemFamily>(NewElem));
			}
		}
	}
}
