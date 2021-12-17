using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class UpdateDtoBase
	{
		[Required]
		[MaxLength(128)]
		public string ModifiedUser { get; set; }
	}
}