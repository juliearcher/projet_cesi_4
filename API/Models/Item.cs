using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	/*
	** entity.HasIndex(item => new { item.Code }).IsUnique(true);
	** entity.Property(e => e.RealStock).HasDefaultValue(0).ValueGeneratedOnAdd();
	** entity.Property(e => e.VirtualStock).HasDefaultValue(0).ValueGeneratedOnAdd();
	*/
	public class Item : BaseModel
	{
		[Required]
		[MaxLength(15)]
		public string Code { get; set; }

		[Required]
		[MaxLength(256)]
		public string Caption { get; set; }

		public string Description { get; set; }

		public string ClearDescription { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }

		[Required]
		public float RealStock { get; set; }

		[Required]
		public float VirtualStock { get; set; }

		[Required]
		[Column(TypeName ="money")]
		public decimal SalePrice { get; set; }

		[Required]
		[Column(TypeName = "money")]
		public decimal PurchasePrice { get; set; }

		[Required]
		public float Vat { get; set; }

		public System.Nullable<int> ItemFamilyId { get; set; }
		public virtual ItemFamily ItemFamily { get; set; }

		public System.Nullable<int> SupplierId { get; set; }
		public virtual Supplier Supplier { get; set; }

		[ForeignKey("ItemId")]
		public IEnumerable<OrderLine> OrderLines { get; set; }
		[ForeignKey("ItemId")]
		public IEnumerable<PurchaseOrderLine> PurchaseOrderLines { get; set; }
		[ForeignKey("ItemId")]
		public IEnumerable<InventoryLine> InventoryLines { get; set; }
	}
}