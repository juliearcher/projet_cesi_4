using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class ReadDtoBase
	{
		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }
	}
}