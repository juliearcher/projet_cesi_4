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
	public class CustomerFormViewModel : FormViewModelBase
	{
		public CustomerFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			_listViewModel = listViewModel;
			_mapper = mapper;
			_oldElem = elem;
			_mode = elem == null ? FormViewModelBase.EditMode.CREATE : FormViewModelBase.EditMode.UPDATE;
			NewElem = elem == null ? new CustomerDataError() :  _mapper.Map<CustomerDataError>(elem);
		}

		public override bool IsValid()
		{
			return false;
		}

		public async override Task SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				await _apiServicesCollection.CustomerService.CreateCustomer(_mapper.Map<Customer>(NewElem));
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.CustomerService.UpdateCustomer(_mapper.Map<Customer>(NewElem));
			}
		}
	}
}
