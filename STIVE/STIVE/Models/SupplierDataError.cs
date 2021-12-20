using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class SupplierDataError : DataErrorModelBase, ISupplier
	{
		private string _code;
		public string Code
		{
			get => _code;
			set
			{
				_code = value;
				ClearErrors(nameof(Code));
				/*if (...)
				{
					AddError(nameof(Code), "...");
				}*/
				OnPropertyChanged(nameof(Code));
			}
		}

		private string _name;
		public string Name
		{
			get => _name;
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
			get => _civility;
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
			get => _notes;
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

		private string _invoicingAddress_Address1;
		public string InvoicingAddress_Address1
		{
			get => _invoicingAddress_Address1;
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
			get => _invoicingAddress_City;
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
			get => _invoicingAddress_ZipCode;
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
			get => _invoicingContact_Civility;
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
			get => _invoicingContact_Name;
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
			get => _invoicingContact_FirstName;
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
			get => _invoicingContact_Email;
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
			get => _invoicingContact_Phone;
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
			get => _invoicingContact_CellPhone;
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

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public SupplierDataError(Supplier supplier = null)
		{
			if (supplier != null)
			{
				Code = supplier.Code;
				Name = supplier.Name;
				Civility = supplier.Civility;
				Notes = supplier.Notes;
				InvoicingAddress_Address1 = supplier.InvoicingAddress_Address1;
				InvoicingAddress_City = supplier.InvoicingAddress_City;
				InvoicingAddress_ZipCode = supplier.InvoicingAddress_ZipCode;
				InvoicingContact_Civility = supplier.InvoicingContact_Civility;
				InvoicingContact_Name = supplier.InvoicingContact_Name;
				InvoicingContact_FirstName = supplier.InvoicingContact_FirstName;
				InvoicingContact_Email = supplier.InvoicingContact_Email;
				InvoicingContact_Phone = supplier.InvoicingContact_Phone;
				InvoicingContact_CellPhone = supplier.InvoicingContact_CellPhone;
				Id = supplier.Id;
				SysCreatedDate = supplier.SysCreatedDate;
				SysModifiedDate = supplier.SysModifiedDate;
				CreatedUser = supplier.CreatedUser;
				ModifiedUser = supplier.ModifiedUser;
			}
		}

	}
}
