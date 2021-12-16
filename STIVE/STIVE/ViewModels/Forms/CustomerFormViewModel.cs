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
		private bool _deliverySameAsInvoicing;
		public bool DeliverySameAsInvoicing
		{
			get
			{
				return _deliverySameAsInvoicing;
			}
			set
			{
				_deliverySameAsInvoicing= value;
				ShowDeliveryInfos = !value;
				OnPropertyChanged(nameof(DeliverySameAsInvoicing));
			}
		}
		private bool _showDeliveryInfos;
		public bool ShowDeliveryInfos
		{
			get
			{
				return _showDeliveryInfos;
			}
			set
			{
				_showDeliveryInfos = value;
				OnPropertyChanged(nameof(ShowDeliveryInfos));
			}
		}

		public CustomerFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_oldElem = elem ?? new Customer();
			_mode = elem == null ? FormViewModelBase.EditMode.CREATE : FormViewModelBase.EditMode.UPDATE;
			NewElem = new CustomerDataError((Customer)_oldElem);
			DeliverySameAsInvoicing = true;
		}

		public override bool IsValid()
		{
			if (DeliverySameAsInvoicing)
			{
				((CustomerDataError)NewElem).DeliveryAddress_Address1 = ((CustomerDataError)NewElem).InvoicingAddress_Address1;
				((CustomerDataError)NewElem).DeliveryAddress_City = ((CustomerDataError)NewElem).InvoicingAddress_City;
				((CustomerDataError)NewElem).DeliveryAddress_ZipCode = ((CustomerDataError)NewElem).InvoicingAddress_ZipCode;
				((CustomerDataError)NewElem).DeliveryContact_CellPhone = ((CustomerDataError)NewElem).InvoicingContact_CellPhone;
				((CustomerDataError)NewElem).DeliveryContact_Civility = ((CustomerDataError)NewElem).InvoicingContact_Civility;
				((CustomerDataError)NewElem).DeliveryContact_Email = ((CustomerDataError)NewElem).InvoicingContact_Email;
				((CustomerDataError)NewElem).DeliveryContact_FirstName = ((CustomerDataError)NewElem).InvoicingContact_FirstName;
				((CustomerDataError)NewElem).DeliveryContact_Name = ((CustomerDataError)NewElem).InvoicingContact_Name;
				((CustomerDataError)NewElem).DeliveryContact_Phone = ((CustomerDataError)NewElem).InvoicingContact_Phone;
			}
			((CustomerDataError)NewElem).CreatedUser = "admin";
			((CustomerDataError)NewElem).ModifiedUser = "admin";
			return true;
		}

		public async override Task SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				Customer newCustomer = await _apiServicesCollection.CustomerService.CreateCustomer(_mapper.Map<Customer>(NewElem));
				_oldElem = newCustomer;
				NewElem = new CustomerDataError(newCustomer);
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.CustomerService.UpdateCustomer(_mapper.Map<Customer>(NewElem));
			}
		}
	}
}
