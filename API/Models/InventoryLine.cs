using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class InventoryLine : BaseModel
	{
		[Required]
		public int LineOrder { get; set; }

		[Required]
		public int InventoryId { get; set; }
		public virtual Inventory Inventory { get; set; }

		public string Description { get; set; }

		public string ClearDescription { get; set; }

		[Required]
		public int NewStock { get; set; }

		[Required]
		public int ItemId { get; set; }
		public virtual Item Item { get; set; }
	}
}