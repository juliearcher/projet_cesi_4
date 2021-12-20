using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class ItemFamilyDataError : DataErrorModelBase, IItemFamily
	{
		private string _code;
		public string Code
		{
			get => _code;
			set
			{
				_code = value;
				/*ClearErrors(nameof(Code));
				if (...)
				{
					AddError(nameof(Code), "...");
				}*/
				OnPropertyChanged(nameof(Code));
			}
		}

		private string _designation;
		public string Designation
		{
			get => _designation;
			set
			{
				_designation = value;
				/*ClearErrors(nameof(Designation));
				if (...)
				{
					AddError(nameof(Designation), "...");
				}*/
				OnPropertyChanged(nameof(Designation));
			}
		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public ItemFamilyDataError(ItemFamily itemFamily = null)
		{
			if (itemFamily != null)
			{
				Code = itemFamily.Code;
				Designation = itemFamily.Designation;
				Id = itemFamily.Id;
				SysCreatedDate = itemFamily.SysCreatedDate;
				SysModifiedDate = itemFamily.SysModifiedDate;
				CreatedUser = itemFamily.CreatedUser;
				ModifiedUser = itemFamily.ModifiedUser;
			}
		}
	}
}
