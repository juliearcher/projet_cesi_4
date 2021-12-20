using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public class Inventory : ApiModelBase, IInventory
	{
		public DateTime DocumentDate { get; set; }
		public string DocumentNumber { get; set; }
		public int DocumentState { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }
		public IEnumerable<IInventoryLine> InventoryLines { get; set; }

	}
}
