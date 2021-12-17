using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class InventoryUpdateDto : UpdateDtoBase
	{
		[Required]
		public int DocumentState { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }

		public IEnumerable<InventoryLineUpdateDto> InventoryLines { get; set; }
	}
}