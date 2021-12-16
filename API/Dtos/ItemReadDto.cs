using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class ItemReadDto : ReadDtoBase
	{
		public string Code { get; set; }
		public string Caption { get; set; }
		public string Description { get; set; }
		public string ClearDescription { get; set; }
		public string Notes { get; set; }
		public string NotesClear { get; set; }

		public float RealStock { get; set; }
		public float VirtualStock { get; set; }
		public decimal SalePrice { get; set; }
		public decimal PurchasePrice { get; set; }
		public float Vat { get; set; }

		public System.Nullable<int> ItemFamilyId { get; set; }
		public int SupplierId { get; set; }
	}
}