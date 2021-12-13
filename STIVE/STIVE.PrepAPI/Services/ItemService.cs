using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class ItemService : IItemService
	{
		public async Task<IEnumerable<Item>> GetAllItems()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var itemList = await client.GetAsync<IEnumerable<Item>>("items");
				return itemList;
			}
		}

		public async Task<Item> GetItemById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var item = await client.GetAsync<Item>("items/" + id);
				return item;
			}
		}

		public async Task<Item> CreateItem(Item item)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<Item, Item>("items/", item);
				return response;
			}
		}

		public async Task UpdateItem(Item item)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<Item, int>("items/" + item.Id, item);
			}
		}

		public async Task DeleteItem(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("items/" + id);
			}
		}
	}
}
