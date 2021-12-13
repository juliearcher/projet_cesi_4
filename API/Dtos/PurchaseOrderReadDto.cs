using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class PurchaseOrderReadDto : ReadDtoBase
	{
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
		public IEnumerable<PurchaseOrderLineReadDto> PurchaseOrderLines { get; set; }
	}
}