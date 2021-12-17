using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace STIVE.Models
{

	public class OrderDataError : DataErrorModelBase, IOrder
	{
		private string _documentNumber;
		public string DocumentNumber
		{
			get => _documentNumber;
			set
			{
				_documentNumber = value;
				ClearErrors(nameof(DocumentNumber));
				/*if (...)
				{
					AddError(nameof(DocumentNumber), "...");
				}*/
				OnPropertyChanged(DocumentNumber);
			}
		}

		private DateTime _documentDate;
		public DateTime DocumentDate
		{
			get => _documentDate;
			set
			{
				_documentDate = value;
				ClearErrors(nameof(DocumentDate));
				/*if (...)
				{
					AddError(nameof(DocumentDate), "...");
				}*/
				OnPropertyChanged(DocumentDate);
			}
		}

		private DateTime _deliveryDate;
		public DateTime DeliveryDate
		{
			get => _deliveryDate;
			set
			{
				_deliveryDate = value;
				ClearErrors(nameof(DeliveryDate));
				/*if (...)
				{
					AddError(nameof(DeliveryDate), "...");
				}*/
				OnPropertyChanged(DeliveryDate);
			}
		}

		private int _documentState;
		public int DocumentState
		{
			get => _documentState;
			set
			{
				_documentState = value;
				ClearErrors(nameof(DocumentState));
				/*if (...)
				{
					AddError(nameof(DocumentState), "...");
				}*/
				OnPropertyChanged(DocumentState);
			}
		}

		private float _discountRate;
		public float DiscountRate
		{
			get => _discountRate;
			set
			{
				_discountRate = value;
				ClearErrors(nameof(DiscountRate));
				/*if (...)
				{
					AddError(nameof(DiscountRate), "...");
				}*/
				OnPropertyChanged(DiscountRate);
			}
		}

		private decimal _amountVatExluded;
		public decimal AmountVatExcluded
		{
			get => _amountVatExluded;
			set
			{
				_amountVatExluded = value;
				ClearErrors(nameof(AmountVatExcluded));
				/*if (...)
				{
					AddError(nameof(AmountVatExcluded), "...");
				}*/
				OnPropertyChanged(AmountVatExcluded);
			}
		}

		private decimal _amountVatExcludedWithDiscount;
		public decimal AmountVatExcludedWithDiscount
		{
			get => _amountVatExcludedWithDiscount;
			set
			{
				_amountVatExcludedWithDiscount = value;
				ClearErrors(nameof(AmountVatExcludedWithDiscount));
				/*if (...)
				{
					AddError(nameof(AmountVatExcludedWithDiscount), "...");
				}*/
				OnPropertyChanged(AmountVatExcludedWithDiscount);
			}
		}

		private decimal _amountVatIncluded;
		public decimal AmountVatIncluded
		{
			get => _amountVatIncluded;
			set
			{
				_amountVatIncluded = value;
				ClearErrors(nameof(AmountVatIncluded));
				/*if (...)
				{
					AddError(nameof(AmountVatIncluded), "...");
				}*/
				OnPropertyChanged(AmountVatIncluded);
			}
		}

		private decimal _vatAmount;
		public decimal VatAmount
		{
			get => _vatAmount;
			set
			{
				_vatAmount = value;
				ClearErrors(nameof(VatAmount));
				/*if (...)
				{
					AddError(nameof(VatAmount), "...");
				}*/
				OnPropertyChanged(VatAmount);
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
				OnPropertyChanged(Notes);
			}
		}

		private string NotesClear;
		public string NotesClear
		{
			get => NotesClear;
			set
			{
				NotesClear = value;
				ClearErrors(nameof(NotesClear));
				/*if (...)
				{
					AddError(nameof(NotesClear), "...");
				}*/
				OnPropertyChanged(NotesClear);
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
				OnPropertyChanged(InvoicingAddress_Address1);
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
				OnPropertyChanged(InvoicingAddress_City);
			}
		}

		private string _invoicingAddress_ZipCode;
		public string InvoicingAdress_ZipCode
		{
			get => _invoicingAddress_ZipCode;
			set
			{
				_invoicingAddress_ZipCode = value;
				ClearErrors(nameof(InvoicingAdress_ZipCode));
				/*if (...)
				{
					AddError(nameof(InvoicingAdress_ZipCode), "...");
				}*/
				OnPropertyChanged(InvoicingAdress_ZipCode);
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
				OnPropertyChanged(InvoicingContact_Civility);
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
				OnPropertyChanged(InvoicingContact_Name);
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
				OnPropertyChanged(InvoicingContact_FirstName;
			}
		}

		private string _invoicingContact_Email;
		public string InvoicingContact_Email
		{
			get => _invoicingContact_Email;
			set
			{
				_invoicingContact_Civility = value;
				ClearErrors(nameof(InvoicingContact_Email));
				/*if (...)
				{
					AddError(nameof(InvoicingContact_Email), "...");
				}*/
				OnPropertyChanged(InvoicingContact_Email);
			}
		}

		private string _invoicingContact_Phone;
		public string InvoicingContact_Phone
		{
			get => _invoicingContact_Phone;
			set
			{
				_invoicingContact_Phone = value;
				ClearErrors(nameof(InvoicingContact_Phone);
				/*if (...)
				{
					AddError(nameof(InvoicingContact_Phone), "...");
				}*/
				OnPropertyChanged(InvoicingContact_Phone);
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
				OnPropertyChanged(InvoicingContact_CellPhone);
			}
		}

		private string _deliveryAddress_Address1;
		public string DeliveryAddress_Address1
		{
			get => _deliveryAddress_Address1;
			set
			{
				_deliveryAddress_Address1 = value;
				ClearErrors(nameof(DeliveryAddress_Address1));
				/*if (...)
				{
					AddError(nameof(DeliveryAddress_Address1), "...");
				}*/
				OnPropertyChanged(DeliveryAddress_Address1);
			}
		}

		private string _deliveryAddress_City;
		public string DeliveryAddress_City
		{
			get => _deliveryAddress_City;
			set
			{
				_deliveryAddress_City = value;
				ClearErrors(nameof(DeliveryAddress_City));
				/*if (...)
				{
					AddError(nameof(DeliveryAddress_City), "...");
				}*/
				OnPropertyChanged(DeliveryAddress_City);
			}
		}

		private string _deliveryAddress_ZipCode;
		public string DeliveryAddress_ZipCode
		{
			get => _deliveryAddress_ZipCode;
			set
			{
				_deliveryAddress_ZipCode = value;
				ClearErrors(nameof(DeliveryAddress_ZipCode));
				/*if (...)
				{
					AddError(nameof(DeliveryAddress_ZipCode), "...");
				}*/
				OnPropertyChanged(DeliveryAddress_ZipCode);
			}
		}

		private string _deliveryContact_Civility;
		public string DeliveryContact_Civility
		{
			get => _deliveryContact_Civility;
			set
			{
				_deliveryContact_Civility = value;
				ClearErrors(nameof(DeliveryContact_Civility));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Civility), "...");
				}*/
				OnPropertyChanged(DeliveryContact_Civility);
			}
		}

		private string _deliveryContact_Name;
		public string DeliveryContact_Name
		{
			get => _deliveryContact_Name;
			set
			{
				_deliveryContact_Name = value;
				ClearErrors(nameof(DeliveryContact_Name));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Name), "...");
				}*/
				OnPropertyChanged(DeliveryContact_Name);
			}
		}

		private string _deliveryContact_FirstName;
		public string DeliveryContact_FirstName
		{FirstName
			get => _deliveryContact_FirstName;
			set
			{
				_deliveryContact_FirstName = value;
				ClearErrors(nameof(DeliveryContact_FirstName));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_FirstName), "...");
				}*/
				OnPropertyChanged(DeliveryContact_FirstName);
			}
		}

		private string _deliveryContact_Email;
		public string DeliveryContact_Email
		{
			get => _deliveryContact_Email;
			set
			{
				_deliveryContact_Email = value;
				ClearErrors(nameof(DeliveryContact_Email));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Email), "...");
				}*/
				OnPropertyChanged(DeliveryContact_Email);
			}
		}

		private string _deliveryContact_Phone;
		public string DeliveryContact_Phone
		{
			get => _deliveryContact_Phone;
			set
			{
				_deliveryContact_Phone = value;
				ClearErrors(nameof(DeliveryContact_Phone));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_Phone), "...");
				}*/
				OnPropertyChanged(DeliveryContact_Phone);
			}
		}

		private string _deliveryContact_CellPhone;
		public string DeliveryContact_CellPhone
		{
			get => _deliveryContact_CellPhone;
			set
			{
				_deliveryContact_CellPhone = value;
				ClearErrors(nameof(DeliveryContact_CellPhone));
				/*if (...)
				{
					AddError(nameof(DeliveryContact_CellPhone), "...");
				}*/
				OnPropertyChanged(DeliveryContact_CellPhone);
			}
		}

		public string DocumentNumber { get; set; }
		public DateTime DocumentDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public int DocumentState { get; set; }
		public float DiscountRate { get; set; }
		public decimal AmountVatExcluded { get; set; }
		public decimal AmountVatExcludedWithDiscount { get; set; }
		public decimal AmountVatIncluded { get; set; }
		public decimal VatAmount { get; set; }
		public string Notes { get; set; }
		public string NotesClear { get; set; }

		#region Informations de facturation

		public string InvoicingAddress_Address1 { get; set; }
		public string InvoicingAddress_City { get; set; }
		public string InvoicingAddress_ZipCode { get; set; }
		public string InvoicingContact_Civility { get; set; }
		public string InvoicingContact_Name { get; set; }
		public string InvoicingContact_FirstName { get; set; }
		public string InvoicingContact_Email { get; set; }
		public string InvoicingContact_Phone { get; set; }
		public string InvoicingContact_CellPhone { get; set; }

		#endregion

		#region Informations de livraison

		public string DeliveryAddress_Address1 { get; set; }
		public string DeliveryAddress_City { get; set; }
		public string DeliveryAddress_ZipCode { get; set; }
		public string DeliveryContact_Civility { get; set; }
		public string DeliveryContact_Name { get; set; }
		public string DeliveryContact_FirstName { get; set; }
		public string DeliveryContact_Email { get; set; }
		public string DeliveryContact_Phone { get; set; }
		public string DeliveryContact_CellPhone { get; set; }
		#endregion

		public int CustomerId { get; set; }

		public IEnumerable<OrderLine> OrderLines { get; set; }

		public OrderDataError(Order order = null)
		{
			if (order != null)
			{
				DocumentNumber = oder.DocumentNumber;
				DocumentDate = oder.DocumentDate;
				DeliveryDate = oder.DeliveryDate;
				DocumentState = oder.DocumentState;
				DiscountRate = oder.DiscountRate;
				AmountVatExcluded = oder.AmountVatExcluded;
				AmountVatExcludedWithDiscount = oder.AmountVatExcludedWithDiscount;
				AmountVatIncluded = oder.AmountVatIncluded;
				VatAmount = oder.VatAmount;
				Notes = oder.Notes;
				NotesClear = oder.NotesClear;
				InvoicingAddress_Address1 = oder.InvoicingAddress_Address1;
				InvoicingAddress_City = oder.InvoicingAddress_City;
				InvoicingAddress_ZipCode = oder.InvoicingAddress_ZipCode;
				InvoicingContact_Civility = oder.InvoicingContact_Civility;
				InvoicingContact_Name = oder.InvoicingContact_Name;
				InvoicingContact_FirstName = oder.InvoicingContact_FirstName;
				InvoicingContact_Email = oder.InvoicingContact_Email;
				InvoicingContact_Phone = oder.InvoicingContact_Phone;
				InvoicingContact_CellPhone = oder.InvoicingContact_CellPhone;
				DeliveryAddress_Address1 = oder.DeliveryAddress_Address1;
				DeliveryAddress_City = oder.DeliveryAddress_City
				DeliveryAddress_ZipCode = oder.DeliveryAddress_Zipcode;
				DeliveryContact_Civility = order.DeliveryConcact_Civility;
				DeliveryContact_Name = order.DeliveryConcact_Name;
				DeliveryContact_FirstName = order.DeliveryConcact_FirstName;
				DeliveryContact_Email = order.DeliveryConcact_Email;
				DeliveryContact_Phone = order.DeliveryConcact_Phone;
				DeliveryContact_CellPhone = order.DeliveryConcact_CellPhone;
			}
		}
	}
}
