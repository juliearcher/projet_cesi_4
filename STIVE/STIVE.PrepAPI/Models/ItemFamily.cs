using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public class ItemFamily : ApiModelBase, IItemFamily
	{
		public string Code { get; set; }
		public string Designation { get; set; }
	}
}
