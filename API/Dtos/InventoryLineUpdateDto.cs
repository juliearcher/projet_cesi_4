using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class InventoryLineUpdateDto : UpdateDtoBase
	{
		[Required]
		public int LineOrder { get; set; }

		public string Description { get; set; }

		public string ClearDescription { get; set; }

		[Required]
		public int NewStock { get; set; }

		[Required]
		public int ItemId { get; set; }
	}
}