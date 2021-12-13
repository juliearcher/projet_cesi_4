using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class PurchaseOrderUpdateDto : UpdateDtoBase
	{
		[Required]
		public DateTime DeliveryDate { get; set; }

		[Required]
		public int DocumentState { get; set; }

		[Required]
		public float DiscountRate { get; set; }

		[Required]
		public decimal AmountVatExcluded { get; set; }

		[Required]
		public decimal AmountVatExcludedWithDiscount { get; set; }

		[Required]
		public decimal AmountVatIncluded { get; set; }

		[Required]
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
		public IEnumerable<PurchaseOrderLineUpdateDto> PurchaseOrderLines { get; set; }
	}
}