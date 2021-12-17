using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface IItemService
	{
		Task<IEnumerable<Item>> GetAllItems();
		Task<Item> GetItemById(long id);
		Task<Item> CreateItem(Item item);
		Task UpdateItem(Item item);
		Task DeleteItem(long id);
	}
}
