using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public class OrderLine : ApiModelBase, IOrderLine
	{
		public int LineOrder { get; set; }
		public float DiscountRate { get; set; }
		public string Description { get; set; }
		public string ClearDescription { get; set; }
		public decimal SalePrice { get; set; }
		public float Vat { get; set; }
		public System.Nullable<int> ItemId { get; set; }
		public int Quantity { get; set; }
	}
}
