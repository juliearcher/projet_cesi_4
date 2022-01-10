using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public class PurchaseOrder : ApiModelBase, IPurchaseOrder
	{
		public bool IsValidated { get => DocumentState == (int)IPurchaseOrder.PurchaseOrderState.Received; }

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

		public int SupplierId { get; set; }
		public IEnumerable<IPurchaseOrderLine> PurchaseOrderLines { get; set; } = new ObservableCollection<PurchaseOrderLine>();
	}
}
