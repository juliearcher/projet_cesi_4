using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class ItemUpdateDto : UpdateDtoBase
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
		public decimal SalePrice { get; set; }

		[Required]
		public decimal PurchasePrice { get; set; }

		[Required]
		public float Vat { get; set; }

		public System.Nullable<int> ItemFamilyId { get; set; }
		public System.Nullable<int> SupplierId { get; set; }
	}
}