using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class OrderLineUpdateDto : UpdateDtoBase
	{
		[Required]
		public int LineOrder { get; set; }

		[Required]
		public float DiscountRate { get; set; }

		public string Description { get; set; }

		public string ClearDescription { get; set; }

		[Required]
		public decimal SalePrice { get; set; }

		[Required]
		public float Vat { get; set; }

		public System.Nullable<int> ItemId { get; set; }

		[Required]
		public int Quantity { get; set; }
	}
}