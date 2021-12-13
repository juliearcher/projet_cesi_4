using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class CreateDtoBase
	{
		[Required]
		[MaxLength(128)]
		public string CreatedUser { get; set; }
		[Required]
		[MaxLength(128)]
		public string ModifiedUser { get; set; }
	}
}