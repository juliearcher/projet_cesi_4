using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class Order : BaseModel
	{
		public enum OrderState
		{
			NotDelivered,
			Delivered
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

		#region Informations de livraison

		[Required]
		[MaxLength(256)]
		public string DeliveryAddress_Address1 { get; set; }
		[Required]
		[MaxLength(128)]
		public string DeliveryAddress_City { get; set; }
		[Required]
		[MaxLength(7)]
		public string DeliveryAddress_ZipCode { get; set; }

		[MaxLength(16)]
		public string DeliveryContact_Civility { get; set; }
		[MaxLength(256)]
		public string DeliveryContact_Name { get; set; }
		[MaxLength(256)]
		public string DeliveryContact_FirstName { get; set; }
		[Required]
		[MaxLength(256)]
		public string DeliveryContact_Email { get; set; }
		[MaxLength(16)]
		public string DeliveryContact_Phone { get; set; }
		[MaxLength(16)]
		public string DeliveryContact_CellPhone { get; set; }
		#endregion

		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		[ForeignKey("OrderId")]
		public IEnumerable<OrderLine> OrderLines { get; set; }
	}
}