using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class InventoryLineDataError : DataErrorModelBase, IInventoryLine
	{
		private int _lineOrder;
		public int LineOrder
		{
			get => _lineOrder;
			set
			{
				_lineOrder = value;
				/*ClearErrors(nameof(LineOrder));
				if (...)
				{
					AddError(nameof(LineOrder), "...");
				}*/
				OnPropertyChanged(nameof(LineOrder));
			}
		}

		private string _caption;
		public string Caption
		{
			get => _caption;
			set
			{
				_caption = value;
				/*ClearErrors(nameof(Caption));
				if (...)
				{
					AddError(nameof(Caption), "...");
				}*/
				OnPropertyChanged(nameof(Caption));
			}
		}

		private string _description;
		public string Description
		{
			get => _description;
			set
			{
				_description = value;
				/*ClearErrors(nameof(Description));
				if (...)
				{
					AddError(nameof(Description), "...");
				}*/
				OnPropertyChanged(nameof(Description));
			}
		}

		private string _clearDescription;
		public string ClearDescription
		{
			get => _clearDescription;
			set
			{
				_clearDescription = value;
				/*ClearErrors(nameof(ClearDescription));
				if (...)
				{
					AddError(nameof(ClearDescription), "...");
				}*/
				OnPropertyChanged(nameof(ClearDescription));
			}
		}

		private float _oldStock;
		public float OldStock
		{
			get => _oldStock;
			set
			{
				_oldStock = value;
				/*ClearErrors(nameof(OldStock));
				if (...)
				{
					AddError(nameof(OldStock), "...");
				}*/
				OnPropertyChanged(nameof(OldStock));
			}
		}

		private int _newStock;
		public int NewStock
		{
			get => _newStock;
			set
			{
				_newStock = value;
				/*ClearErrors(nameof(NewStock));
				if (...)
				{
					AddError(nameof(NewStock), "...");
				}*/
				OnPropertyChanged(nameof(NewStock));
			}
		}

		private int _itemId;
		public int ItemId
		{
			get => _itemId;
			set
			{
				_itemId = value;
				/*ClearErrors(nameof(ItemId));
				if (...)
				{
					AddError(nameof(ItemId), "...");
				}*/
				OnPropertyChanged(nameof(ItemId));
			}
		}

		private Item _item;
		public Item Item
		{
			get => _item;
			set
			{
				_item = value;
				if (_item! != null)
				{
					Caption = _item.Caption;
					ClearDescription = _item.ClearDescription;
					ItemId = value.Id;
					OldStock = value.RealStock;
				}
				/*ClearErrors(nameof(Item));
				if (...)
				{
					AddError(nameof(Item), "...");
				}*/
				OnPropertyChanged(nameof(Item));
			}
		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public InventoryLineDataError(InventoryLine inventoryLine = null)
		{
			if (inventoryLine != null)
			{
				LineOrder = inventoryLine.LineOrder;
				Description = inventoryLine.Description;
				ClearDescription = inventoryLine.ClearDescription;
				NewStock = inventoryLine.NewStock;
				ItemId = inventoryLine.ItemId;
				Id = inventoryLine.Id;
				SysCreatedDate = inventoryLine.SysCreatedDate;
				SysModifiedDate = inventoryLine.SysModifiedDate;
				CreatedUser = inventoryLine.CreatedUser;
				ModifiedUser = inventoryLine.ModifiedUser;
			}
		}
	}
}
