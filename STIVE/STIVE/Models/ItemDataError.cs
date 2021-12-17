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
				OnPropertyChanged(Code);
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
				OnPropertyChanged(Caption);
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
				OnPropertyChanged(Description);
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
				OnPropertyChanged(ClearDescription);
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
				OnPropertyChanged(Notes);
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
				OnPropertyChanged(NotesClear);
			}
		}

		private string _realStock;
		public string RealStock
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
				OnPropertyChanged(RealStock);
			}
		}

		private string virtualStock;
		public string VirtualStock
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
				OnPropertyChanged(VirtualStock);
			}
		}

		private string _salePrice;
		public string SalePrice
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
				OnPropertyChanged(SalePrice);
			}
		}

		private string _purchasePrice;
		public string PurchasePrice
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
				OnPropertyChanged(PurchasePrice);
			}
		}

		private string _vat;
		public string Vat
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
				OnPropertyChanged(Vat);
			}
		}

		private string _itemFamilyId;
		public string ItemFamilyId
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
				OnPropertyChanged(ItemFamilyId);
			}
		}

		private string _supplierId;
		public string SupplierId
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
				OnPropertyChanged(SupplierId);
			}
		}

		public string Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string ClearDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string NotesClear { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public float RealStock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public float VirtualStock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public decimal SalePrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public decimal PurchasePrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public float Vat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int? ItemFamilyId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int? SupplierId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime SysCreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime SysModifiedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string CreatedUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string ModifiedUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
			}
		}
	}
}
