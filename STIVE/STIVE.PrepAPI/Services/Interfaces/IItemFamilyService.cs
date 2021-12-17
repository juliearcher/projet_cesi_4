using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface IItemFamilyService
	{
		Task<IEnumerable<ItemFamily>> GetAllItemFamilies();
		Task<ItemFamily> GetItemFamilyById(long id);
		Task<ItemFamily> CreateItemFamily(ItemFamily itemFamily);
		Task UpdateItemFamily(ItemFamily itemFamily);
		Task DeleteItemFamily(long id);
	}
}
