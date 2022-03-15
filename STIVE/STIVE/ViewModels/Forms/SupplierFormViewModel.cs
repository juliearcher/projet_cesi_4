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
	public class SupplierFormViewModel : FormViewModelBase
	{

		public SupplierFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_oldElem = elem ?? new Supplier();
			_mode = elem == null ? FormViewModelBase.EditMode.CREATE : FormViewModelBase.EditMode.UPDATE;
			NewElem = new SupplierDataError((Supplier)_oldElem);
		}

		public override bool IsValid()
		{
			((SupplierDataError)NewElem).CreatedUser = "admin";
			((SupplierDataError)NewElem).ModifiedUser = "admin";
			return true;
		}

		public async override Task SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				Supplier newSupplier = await _apiServicesCollection.SupplierService.CreateSupplier(_mapper.Map<Supplier>(NewElem));
				_oldElem = newSupplier;
				NewElem = new SupplierDataError(newSupplier);
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.SupplierService.UpdateSupplier(_mapper.Map<Supplier>(NewElem));
			}
		}
	}
}
