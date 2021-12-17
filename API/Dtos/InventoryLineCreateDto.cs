using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class InventoryLineCreateDto : CreateDtoBase
	{
		[Required]
		public int LineOrder { get; set; }

		//[Required]
		//public int InventoryId { get; set; }

		public string Description { get; set; }

		public string ClearDescription { get; set; }

		[Required]
		public int NewStock { get; set; }

		[Required]
		public int ItemId { get; set; }
	}
}