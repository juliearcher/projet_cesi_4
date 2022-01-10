using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace STIVE.Models
{

	public class PurchaseOrderDataError : DataErrorModelBase, IPurchaseOrder
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
				OnPropertyChanged(nameof(DocumentNumber));
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
				OnPropertyChanged(nameof(DocumentDate));
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
				OnPropertyChanged(nameof(DeliveryDate));
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
				OnPropertyChanged(nameof(DocumentState));
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
				OnPropertyChanged(nameof(DiscountRate));
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
				OnPropertyChanged(nameof(AmountVatExcluded));
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
				OnPropertyChanged(nameof(AmountVatExcludedWithDiscount));
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
				OnPropertyChanged(nameof(AmountVatIncluded));
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
				OnPropertyChanged(nameof(VatAmount));
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

		private string _notesClear;
		public string NotesClear
		{
			get => _notesClear;
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
					AddError(nameof(InvoicingAdress_ZipCode), "...");
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

		private int _supplierId;
		public int SupplierId
		{
			get => _supplierId;
			set
			{
				_supplierId = value;
				ClearErrors(nameof(SupplierId));
				/*if (...)
				{
					AddError(nameof(SupplierId), "...");
				}*/
				OnPropertyChanged(nameof(SupplierId));
			}
		}

		private IEnumerable<IPurchaseOrderLine> _purchasePurchaseOrderLines;
		public IEnumerable<IPurchaseOrderLine> PurchaseOrderLines
		{
			get => _purchasePurchaseOrderLines;
			set
			{
				_purchasePurchaseOrderLines = value;
				ClearErrors(nameof(PurchaseOrderLines));
				/*if (...)
				{
					AddError(nameof(PurchaseOrderLines), "...");
				}*/
				OnPropertyChanged(nameof(PurchaseOrderLines));
			}
		}

		private decimal _netAmount;
		public decimal NetAmount
		{
			get => _netAmount;
			set
			{
				_netAmount = value;
				ClearErrors(nameof(NetAmount));
				/*if (...)
				{
					AddError(nameof(NetAmount), "...");
				}*/
				OnPropertyChanged(nameof(NetAmount));
			}

		}
		private decimal _netAmountWithDiscount;
		public decimal NetAmountWithDiscount
		{
			get => _netAmountWithDiscount;
			set
			{
				_netAmountWithDiscount = value;
				ClearErrors(nameof(NetAmountWithDiscount));
				/*if (...)
				{
					AddError(nameof(NetAmountWithDiscount), "...");
				}*/
				OnPropertyChanged(nameof(NetAmountWithDiscount));
			}

		}
		private decimal _netAmountVatIncluded;
		public decimal NetAmountVatIncluded
		{
			get => _netAmountVatIncluded;
			set
			{
				_netAmountVatIncluded = value;
				ClearErrors(nameof(NetAmountVatIncluded));
				/*if (...)
				{
					AddError(nameof(NetAmountVatIncluded), "...");
				}*/
				OnPropertyChanged(nameof(NetAmountVatIncluded));
			}

		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public PurchaseOrderDataError(PurchaseOrder order = null)
		{
			if (order != null)
			{
				DocumentNumber = order.DocumentNumber;
				DocumentDate = order.DocumentDate;
				DeliveryDate = order.DeliveryDate;
				DocumentState = order.DocumentState;
				DiscountRate = order.DiscountRate;
				AmountVatExcluded = order.AmountVatExcluded;
				AmountVatExcludedWithDiscount = order.AmountVatExcludedWithDiscount;
				AmountVatIncluded = order.AmountVatIncluded;
				VatAmount = order.VatAmount;
				Notes = order.Notes;
				NotesClear = order.NotesClear;
				InvoicingAddress_Address1 = order.InvoicingAddress_Address1;
				InvoicingAddress_City = order.InvoicingAddress_City;
				InvoicingAddress_ZipCode = order.InvoicingAddress_ZipCode;
				InvoicingContact_Civility = order.InvoicingContact_Civility;
				InvoicingContact_Name = order.InvoicingContact_Name;
				InvoicingContact_FirstName = order.InvoicingContact_FirstName;
				InvoicingContact_Email = order.InvoicingContact_Email;
				InvoicingContact_Phone = order.InvoicingContact_Phone;
				InvoicingContact_CellPhone = order.InvoicingContact_CellPhone;
				SupplierId = order.SupplierId;

				Id = order.Id;
				SysCreatedDate = order.SysCreatedDate;
				SysModifiedDate = order.SysModifiedDate;
				CreatedUser = order.CreatedUser;
				ModifiedUser = order.ModifiedUser;
			}
			if (PurchaseOrderLines == null)
				PurchaseOrderLines = new ObservableCollection<PurchaseOrderLineDataError>();
		}

		public void LineAmountsChanged()
		{
			decimal netAmount = 0;
			decimal netAmountWithDiscount = 0;
			decimal netAmountVatIncluded = 0;
			foreach (PurchaseOrderLineDataError orderLine in PurchaseOrderLines)
			{
				netAmount += orderLine.NetAmount;
				netAmountWithDiscount += orderLine.NetAmountWithDiscount;
				netAmountVatIncluded += orderLine.NetAmountVatIncluded;
			}
			NetAmount = netAmount;
			NetAmountWithDiscount = netAmountWithDiscount;
			NetAmountVatIncluded = netAmountVatIncluded;
		}
	}
}
