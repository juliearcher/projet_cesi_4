using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class ItemFamilyCreateDto : CreateDtoBase
	{
		[Required]
		[MaxLength(15)]
		public string Code { get; set; }

		[Required]
		[MaxLength(256)]
		public string Designation { get; set; }

	}
}