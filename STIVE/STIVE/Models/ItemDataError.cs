using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class ItemDataError : DataErrorModelBase, IItem
	{
		private string _code;
		public string Code
		{
			get => _code;
			set
			{
				_code = value;
				ClearErrors(nameof(Code));
				/*if (...)
				{
					AddError(nameof(Code), "...");
				}*/
				OnPropertyChanged(nameof(Code));
			}
		}

		private string _caption;
		public string Caption
        {
			get => _caption;
			set
            {
				_caption = value;
				ClearErrors(nameof(Caption));
				/*if (...)
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
				ClearErrors(nameof(Description));
				/*if (...)
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
				ClearErrors(nameof(ClearDescription));
				/*if (...)
				{
					AddError(nameof(ClearDescription), "...");
				}*/
				OnPropertyChanged(nameof(ClearDescription));
			}
		}

		private string _notes;
		public string Notes
		{
			get => _notes;
			set
			{
				_notes = value;
				ClearErrors(nameof(Notes));
				/*if (...)
				{
					AddError(nameof(Notes), "...");
				}*/
				OnPropertyChanged(nameof(Notes));
			}
		}

		private string _notesClear;
		public string NotesClear
		{
			get => _notesClear;
			set
			{
				_notesClear = value;
				ClearErrors(nameof(NotesClear));
				/*if (...)
				{
					AddError(nameof(NotesClear), "...");
				}*/
				OnPropertyChanged(nameof(NotesClear));
			}
		}

		private float _realStock;
		public float RealStock
		{
			get => _realStock;
			set
			{
				_realStock = value;
				ClearErrors(nameof(RealStock));
				/*if (...)
				{
					AddError(nameof(RealStock), "...");
				}*/
				OnPropertyChanged(nameof(RealStock));
			}
		}

		private float virtualStock;
		public float VirtualStock
		{
			get => virtualStock;
			set
			{
				virtualStock = value;
				ClearErrors(nameof(VirtualStock));
				/*if (...)
				{
					AddError(nameof(VirtualStock), "...");
				}*/
				OnPropertyChanged(nameof(VirtualStock));
			}
		}

		private decimal _salePrice;
		public decimal SalePrice
		{
			get => _salePrice;
			set
			{
				_salePrice = value;
				ClearErrors(nameof(SalePrice));
				/*if (...)
				{
					AddError(nameof(SalePrice), "...");
				}*/
				OnPropertyChanged(nameof(SalePrice));
			}
		}

		private decimal _purchasePrice;
		public decimal PurchasePrice
		{
			get => _purchasePrice;
			set
			{
				_purchasePrice = value;
				ClearErrors(nameof(PurchasePrice));
				/*if (...)
				{
					AddError(nameof(PurchasePrice), "...");
				}*/
				OnPropertyChanged(nameof(PurchasePrice));
			}
		}

		private float _vat;
		public float Vat
		{
			get => _vat;
			set
			{
				_vat = value;
				ClearErrors(nameof(Vat));
				/*if (...)
				{
					AddError(nameof(Vat), "...");
				}*/
				OnPropertyChanged(nameof(Vat));
			}
		}

		private int? _itemFamilyId;
		public int? ItemFamilyId
		{
			get => _itemFamilyId;
			set
			{
				_itemFamilyId = value;
				ClearErrors(nameof(ItemFamilyId));
				/*if (...)
				{
					AddError(nameof(ItemFamilyId), "...");
				}*/
				OnPropertyChanged(nameof(ItemFamilyId));
			}
		}

		private int _supplierId;
		public int SupplierId
		{
			get => _supplierId;
			set
			{
				_supplierId = value;
				ClearErrors(nameof(SupplierId));
				/*if (...)
				{
					AddError(nameof(SupplierId), "...");
				}*/
				OnPropertyChanged(nameof(SupplierId));
			}
		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public ItemDataError(Item item = null)
		{
			if (item != null)
			{
				Code = item.Code;
				Caption = item.Caption;
				Description = item.Description;
				ClearDescription = item.ClearDescription;
				Notes = item.Notes;
				NotesClear = item.NotesClear;
				RealStock = item.RealStock;
				VirtualStock = item.VirtualStock;
				SalePrice = item.SalePrice;
				PurchasePrice = item.PurchasePrice;
				Vat = item.Vat;
				ItemFamilyId = item.ItemFamilyId;
				SupplierId = item.SupplierId;
				Id = item.Id;
				SysCreatedDate = item.SysCreatedDate;
				SysModifiedDate = item.SysModifiedDate;
				CreatedUser = item.CreatedUser;
				ModifiedUser = item.ModifiedUser;
			}
		}
	}
}
