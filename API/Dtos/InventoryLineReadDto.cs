using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class InventoryLineReadDto : ReadDtoBase
	{
		public int LineOrder { get; set; }
		//public int InventoryId { get; set; }
		public string Description { get; set; }
		public string ClearDescription { get; set; }
		public int NewStock { get; set; }
		public int ItemId { get; set; }
	}
}