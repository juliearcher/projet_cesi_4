using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class PurchaseOrder : BaseModel
	{
		public enum PurchaseOrderState
		{
			NotReceived,
			Received
		}

		[Required]
		[MaxLength(16)]
		public string DocumentNumber { get; set; }

		[Required]
		[Column(TypeName = "Date")]
		public DateTime DocumentDate { get; set; }

		[Required]
		[Column(TypeName = "Date")]
		public DateTime DeliveryDate { get; set; }

		[Required]
		public int DocumentState { get; set; }

		[Required]
		public float DiscountRate { get; set; }

		[Required]
		[Column(TypeName = "money")]
		public decimal AmountVatExcluded { get; set; }

		[Required]
		[Column(TypeName = "money")]
		public decimal AmountVatExcludedWithDiscount { get; set; }

		[Required]
		[Column(TypeName = "money")]
		public decimal AmountVatIncluded { get; set; }

		[Required]
		[Column(TypeName = "money")]
		public decimal VatAmount { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }

		#region Informations de facturation

		[Required]
		[MaxLength(256)]
		public string InvoicingAddress_Address1 { get; set; }
		[Required]
		[MaxLength(128)]
		public string InvoicingAddress_City { get; set; }
		[Required]
		[MaxLength(7)]
		public string InvoicingAddress_ZipCode { get; set; }

		[MaxLength(16)]
		public string InvoicingContact_Civility { get; set; }
		[MaxLength(256)]
		public string InvoicingContact_Name { get; set; }
		[MaxLength(256)]
		public string InvoicingContact_FirstName { get; set; }
		[MaxLength(256)]
		public string InvoicingContact_Email { get; set; }
		[MaxLength(16)]
		public string InvoicingContact_Phone { get; set; }
		[MaxLength(16)]
		public string InvoicingContact_CellPhone { get; set; }
		#endregion

		public int SupplierId { get; set; }
		public virtual Supplier Supplier { get; set; }

		[ForeignKey("PurchaseOrderId")]
		public IEnumerable<PurchaseOrderLine> PurchaseOrderLines { get; set; }
	}
}