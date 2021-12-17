using API.Models;
using System;
using System.Collections.Generic;

namespace API.Dtos
{
	public partial class InventoryReadDto : ReadDtoBase
	{
		public DateTime DocumentDate { get; set; }
		public string DocumentNumber { get; set; }
		public int DocumentState { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }
		public IEnumerable<InventoryLineReadDto> InventoryLines { get; set; }
	}
}