using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class CustomerDataError : DataErrorModelBase, ICustomer
	{
		private string _code;
		public string Code {
			get
			{
				return _code;
			}
			set
			{
				_code = value;
				ClearErrors(nameof(Code));
				if (_code == null || _code?.Trim().Length == 0)
				{
					AddError(nameof(Code), "Champ obligatoire");
				}
				OnPropertyChanged(nameof(Code));
			}
		}

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				ClearErrors(nameof(Name));
				/*if (...)
				{
					AddError(nameof(Name), "...");
				}*/
				OnPropertyChanged(nameof(Name));
			}
		}

		private string _civility;
		public string Civility
		{
			get
			{
				return _civility;
			}
			set
			{
				_civility = value;
				ClearErrors(nameof(Civility));
				/*if (...)
				{
					AddError(nameof(Civility), "...");
				}*/
				OnPropertyChanged(nameof(Civility));
			}
		}

		private string _notes;
		public string Notes
		{
			get
			{
				return _notes;
			}
			set
			{
				_notes = value;
				ClearErrors(nameof(Notes));
				/*if (...)
				{
					AddError(nameof(Notes), "...");
				}*/
				OnPropertyChanged(nameof(Notes));
			}
		}

		private string _notesClear;
		public string NotesClear
		{
			get
			{
				return _notesClear;
			}
			set
			{
				_notesClear = value;
				ClearErrors(nameof(NotesClear));
				/*if (...)
				{
					AddError(nameof(NotesClear), "...");
				}*/
				OnPropertyChanged(nameof(NotesClear));
			}
		}

		private string _invoicingAddress_Address1;
		public string InvoicingAddress_Address1
		{
			get
			{
				return _invoicingAddress_Address1;
			}
			set
			{
				_invoicingAddress_Address1 = value;
				ClearErrors(nameof(InvoicingAddress_Address1));
				/*if (...)
				{
					AddError(nameof(InvoicingAddress_Address1), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingAddress_Address1));
			}
		}

		private string _invoicingAddress_City;
		public string InvoicingAddress_City
		{
			get
			{
				return _invoicingAddress_City;
			}
			set
			{
				_invoicingAddress_City = value;
				ClearErrors(nameof(InvoicingAddress_City));
				/*if (...)
				{
					AddError(nameof(InvoicingAddress_City), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingAddress_City));
			}
		}

		private string _invoicingAddress_ZipCode;
		public string InvoicingAddress_ZipCode
		{
			get
			{
				return _invoicingAddress_ZipCode;
			}
			set
			{
				_invoicingAddress_ZipCode = value;
				ClearErrors(nameof(InvoicingAddress_ZipCode));
				/*if (...)
				{
					AddError(nameof(InvoicingAddress_ZipCode), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingAddress_ZipCode));
			}
		}

		private string _invoicingContact_Civility;
		public string InvoicingContact_Civility
		{
			get
			{
				return _invoicingContact_Civility;
			}
			set
			{
				_invoicingContact_Civility = value;
				ClearErrors(nameof(InvoicingContact_Civility));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_Civility), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingContact_Civility));
			}
		}

		private string _invoicingContact_Name;
		public string InvoicingContact_Name
		{
			get
			{
				return _invoicingContact_Name;
			}
			set
			{
				_invoicingContact_Name = value;
				ClearErrors(nameof(InvoicingContact_Name));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_Name), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingContact_Name));
			}
		}

		private string _invoicingContact_FirstName;
		public string InvoicingContact_FirstName
		{
			get
			{
				return _invoicingContact_FirstName;
			}
			set
			{
				_invoicingContact_FirstName = value;
				ClearErrors(nameof(InvoicingContact_FirstName));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_FirstName), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingContact_FirstName));
			}
		}

		private string _invoicingContact_Email;
		public string InvoicingContact_Email
		{
			get
			{
				return _invoicingContact_Email;
			}
			set
			{
				_invoicingContact_Email = value;
				ClearErrors(nameof(InvoicingContact_Email));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_Email), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingContact_Email));
			}
		}

		private string _invoicingContact_Phone;
		public string InvoicingContact_Phone
		{
			get
			{
				return _invoicingContact_Phone;
			}
			set
			{
				_invoicingContact_Phone = value;
				ClearErrors(nameof(InvoicingContact_Phone));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_Phone), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingContact_Phone));
			}
		}

		private string _invoicingContact_CellPhone;
		public string InvoicingContact_CellPhone
		{
			get
			{
				return _invoicingContact_CellPhone;
			}
			set
			{
				_invoicingContact_CellPhone = value;
				ClearErrors(nameof(InvoicingContact_CellPhone));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_CellPhone), "...");
				}*/
				OnPropertyChanged(nameof(InvoicingContact_CellPhone));
			}
		}

		private string _deliveryAddress_Address1;
		public string DeliveryAddress_Address1
		{
			get
			{
				return _deliveryAddress_Address1;
			}
			set
			{
				_deliveryAddress_Address1 = value;
				ClearErrors(nameof(DeliveryAddress_Address1));
				/*if (...)
				{
					AddError(nameof(DeliveryAddress_Address1), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryAddress_Address1));
			}
		}

		private string _deliveryAddress_City;
		public string DeliveryAddress_City
		{
			get
			{
				return _deliveryAddress_City;
			}
			set
			{
				_deliveryAddress_City = value;
				ClearErrors(nameof(DeliveryAddress_City));
				/*if (...)
				{
					AddError(nameof(DeliveryAddress_City), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryAddress_City));
			}
		}

		private string _deliveryAddress_ZipCode;
		public string DeliveryAddress_ZipCode
		{
			get
			{
				return _deliveryAddress_ZipCode;
			}
			set
			{
				_deliveryAddress_ZipCode = value;
				ClearErrors(nameof(DeliveryAddress_ZipCode));
				/*if (...)
				{
					AddError(nameof(DeliveryAddress_ZipCode), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryAddress_ZipCode));
			}
		}

		private string _deliveryContact_Civility;
		public string DeliveryContact_Civility
		{
			get
			{
				return _deliveryContact_Civility;
			}
			set
			{
				_deliveryContact_Civility = value;
				ClearErrors(nameof(DeliveryContact_Civility));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Civility), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryContact_Civility));
			}
		}

		private string _deliveryContact_Name;
		public string DeliveryContact_Name
		{
			get
			{
				return _deliveryContact_Name;
			}
			set
			{
				_deliveryContact_Name = value;
				ClearErrors(nameof(DeliveryContact_Name));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Name), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryContact_Name));
			}
		}

		private string _deliveryContact_FirstName;
		public string DeliveryContact_FirstName
		{
			get
			{
				return _deliveryContact_FirstName;
			}
			set
			{
				_deliveryContact_FirstName = value;
				ClearErrors(nameof(DeliveryContact_FirstName));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_FirstName), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryContact_FirstName));
			}
		}

		private string _deliveryContact_Email;
		public string DeliveryContact_Email
		{
			get
			{
				return _deliveryContact_Email;
			}
			set
			{
				_deliveryContact_Email = value;
				ClearErrors(nameof(DeliveryContact_Email));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Email), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryContact_Email));
			}
		}

		private string _deliveryContact_Phone;
		public string DeliveryContact_Phone
		{
			get
			{
				return _deliveryContact_Phone;
			}
			set
			{
				_deliveryContact_Phone = value;
				ClearErrors(nameof(DeliveryContact_Phone));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Phone), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryContact_Phone));
			}
		}

		private string _deliveryContact_CellPhone;
		public string DeliveryContact_CellPhone
		{
			get
			{
				return _deliveryContact_CellPhone;
			}
			set
			{
				_deliveryContact_CellPhone = value;
				ClearErrors(nameof(DeliveryContact_CellPhone));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_CellPhone), "...");
				}*/
				OnPropertyChanged(nameof(DeliveryContact_CellPhone));
			}
		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public CustomerDataError(Customer customer = null)
		{
			if (customer != null)
			{
				Code = customer.Code;
				Name = customer.Name;
				Civility = customer.Civility;
				Notes = customer.Notes;
				NotesClear = customer.NotesClear;
				InvoicingAddress_Address1 = customer.InvoicingAddress_Address1;
				InvoicingAddress_City = customer.InvoicingAddress_City;
				InvoicingAddress_ZipCode = customer.InvoicingAddress_ZipCode;
				InvoicingContact_Civility = customer.InvoicingContact_Civility;
				InvoicingContact_Name = customer.InvoicingContact_Name;
				InvoicingContact_FirstName = customer.InvoicingContact_FirstName;
				InvoicingContact_Email = customer.InvoicingContact_Email;
				InvoicingContact_Phone = customer.InvoicingContact_Phone;
				InvoicingContact_CellPhone = customer.InvoicingContact_CellPhone;
				DeliveryAddress_Address1 = customer.DeliveryAddress_Address1;
				DeliveryAddress_City = customer.DeliveryAddress_City;
				DeliveryAddress_ZipCode = customer.DeliveryAddress_ZipCode;
				DeliveryContact_Civility = customer.DeliveryContact_Civility;
				DeliveryContact_Name = customer.DeliveryContact_Name;
				DeliveryContact_FirstName = customer.DeliveryContact_FirstName;
				DeliveryContact_Email = customer.DeliveryContact_Email;
				DeliveryContact_Phone = customer.DeliveryContact_Phone;
				DeliveryContact_CellPhone = customer.DeliveryContact_CellPhone;
				Id = customer.Id;
				SysCreatedDate = customer.SysCreatedDate;
				SysModifiedDate = customer.SysModifiedDate;
				CreatedUser = customer.CreatedUser;
				ModifiedUser = customer.ModifiedUser;
			}
		}
	}
}
