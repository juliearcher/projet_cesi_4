using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	[NotMapped]
	public class BaseModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public DateTime SysCreatedDate { get; set; }
		[Required]
		public DateTime SysModifiedDate { get; set; }

		[Required]
		[MaxLength(128)]
		public string CreatedUser { get; set; }
		[Required]
		[MaxLength(128)]
		public string ModifiedUser { get; set; }
	}
}