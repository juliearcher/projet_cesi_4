using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class ItemFamily : BaseModel
	{
		[Required]
		[MaxLength(15)]
		public string Code { get; set; }

		[Required]
		[MaxLength(256)]
		public string Designation { get; set; }

		[ForeignKey("ItemFamilyId")]
		public IEnumerable<Item> Items { get; set; }
	}
}