using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public class ApiModelBase : IApiModelBase
	{
		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }
	}
}
