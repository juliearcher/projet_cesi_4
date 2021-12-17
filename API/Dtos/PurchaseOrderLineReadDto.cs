using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class PurchaseOrderLineReadDto : ReadDtoBase
	{
		//public int PurchaseOrderId { get; set; }

		public int LineOrder { get; set; }
		public float DiscountRate { get; set; }
		public string Description { get; set; }
		public string ClearDescription { get; set; }
		public decimal PurchasePrice { get; set; }
		public float Vat { get; set; }
		public System.Nullable<int> ItemId { get; set; }
		public int Quantity { get; set; }
	}
}