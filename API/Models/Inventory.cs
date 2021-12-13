using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class Inventory : BaseModel
	{
		public enum InventoryState
		{
			InProgress,
			Validated
		}

		[Required]
		[Column(TypeName = "Date")]
		public DateTime DocumentDate { get; set; }

		[Required]
		[MaxLength(16)]
		public string DocumentNumber { get; set; }

		[Required]
		public int DocumentState { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }

		[ForeignKey("InventoryId")]
		public virtual IEnumerable<InventoryLine> InventoryLines { get; set; }
	}
}