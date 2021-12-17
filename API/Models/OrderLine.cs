using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class OrderLine : BaseModel
	{
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }

		[Required]
		public int LineOrder { get; set; }

		[Required]
		public float DiscountRate { get; set; } // TODO METTRE A 0 A L'INSERTION

		public string Description { get; set; }

		public string ClearDescription { get; set; }

		[Required]
		[Column(TypeName = "money")]
		public decimal SalePrice { get; set; }

		[Required]
		public float Vat { get; set; }

		public System.Nullable<int> ItemId { get; set; }
		public virtual Item Item { get; set; }

		[Required]
		public int Quantity { get; set; }
	}
}
