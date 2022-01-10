using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class OrderLineDataError : DataErrorModelBase, IOrderLine
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

		private float _discountRate;
		public float DiscountRate
		{
			get => _discountRate;
			set
			{
				_discountRate = value;
				/*ClearErrors(nameof(DiscountRate));
				if (...)
				{
					AddError(nameof(DiscountRate), "...");
				}*/
				OnPropertyChanged(nameof(DiscountRate));
				OnPropertyChanged(nameof(NetAmountWithDiscount));
				OnPropertyChanged(nameof(NetAmountVatIncluded));
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

		private decimal _salePrice;
		public decimal SalePrice
		{
			get => _salePrice;
			set
			{
				_salePrice = value;
				/*ClearErrors(nameof(SalePrice));
				if (...)
				{
					AddError(nameof(SalePrice), "...");
				}*/
				OnPropertyChanged(nameof(SalePrice));
				OnPropertyChanged(nameof(NetAmount));
				OnPropertyChanged(nameof(NetAmountWithDiscount));
				OnPropertyChanged(nameof(NetAmountVatIncluded));
			}
		}

		private float _vat;
		public float Vat
		{
			get => _vat;
			set
			{
				_vat = value;
				/*ClearErrors(nameof(Vat));
				if (...)
				{
					AddError(nameof(Vat), "...");
				}*/
				OnPropertyChanged(nameof(Vat));
				OnPropertyChanged(nameof(NetAmountVatIncluded));
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

		private int _quantity;
		public int Quantity
		{
			get => _quantity;
			set
			{
				_quantity = value;
				/*ClearErrors(nameof(Quantity));
				if (...)
				{
					AddError(nameof(Quantity), "...");
				}*/
				OnPropertyChanged(nameof(Quantity));
				OnPropertyChanged(nameof(NetAmount));
				OnPropertyChanged(nameof(NetAmountWithDiscount));
				OnPropertyChanged(nameof(NetAmountVatIncluded));
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
					SalePrice = _item.SalePrice;
					Vat = _item.Vat;
					ItemId = value.Id;
				}
				/*ClearErrors(nameof(Item));
				if (...)
				{
					AddError(nameof(Item), "...");
				}*/
				OnPropertyChanged(nameof(Item));
			}
		}

		public decimal NetAmount
		{
			get => Quantity * SalePrice;
		}

		public decimal NetAmountWithDiscount
		{
			get => (Quantity * SalePrice)*(decimal)((100 - DiscountRate)/100);
		}

		public decimal NetAmountVatIncluded
		{
			get => NetAmountWithDiscount + NetAmountWithDiscount * (decimal)(Vat/100);
		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public OrderLineDataError(OrderLine orderLine = null)
		{
			if (orderLine != null)
			{
				LineOrder = orderLine.LineOrder;
				DiscountRate = orderLine.DiscountRate;
				Description = orderLine.Description;
				ClearDescription = orderLine.ClearDescription;
				SalePrice = orderLine.SalePrice;
				Vat = orderLine.Vat;
				ItemId = orderLine.ItemId;
				Quantity = orderLine.Quantity;
				Id = orderLine.Id;
				SysCreatedDate = orderLine.SysCreatedDate;
				SysModifiedDate = orderLine.SysModifiedDate;
				CreatedUser = orderLine.CreatedUser;
				ModifiedUser = orderLine.ModifiedUser;
			}
		}
	}
}
