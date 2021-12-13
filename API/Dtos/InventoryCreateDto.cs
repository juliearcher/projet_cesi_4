using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class InventoryCreateDto : CreateDtoBase
	{
		[Required]
		public DateTime DocumentDate { get; set; }

		[Required]
		[MaxLength(16)]
		public string DocumentNumber { get; set; }

		[Required]
		public int DocumentState { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }

		public IEnumerable<InventoryLineCreateDto> InventoryLines { get; set; }
	}
}