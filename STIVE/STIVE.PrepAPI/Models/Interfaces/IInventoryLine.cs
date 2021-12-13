using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public interface IInventoryLine : IApiModelBase
	{
		public int LineOrder { get; set; }
		public string Description { get; set; }
		public string ClearDescription { get; set; }
		public int NewStock { get; set; }
		public int ItemId { get; set; }
	}
}
