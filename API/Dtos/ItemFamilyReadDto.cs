using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class ItemFamilyReadDto : ReadDtoBase
	{
		public string Code { get; set; }
		public string Designation { get; set; }

	}
}