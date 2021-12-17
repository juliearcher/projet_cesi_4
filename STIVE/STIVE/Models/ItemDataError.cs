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
				// TODO
			}
		}
	}
}
