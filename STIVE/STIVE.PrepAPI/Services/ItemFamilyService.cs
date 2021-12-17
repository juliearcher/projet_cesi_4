using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class ItemFamilyService : IItemFamilyService
	{
		public async Task<IEnumerable<ItemFamily>> GetAllItemFamilies()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var itemFamilyList = await client.GetAsync<IEnumerable<ItemFamily>>("itemFamilies");
				return itemFamilyList;
			}
		}

		public async Task<ItemFamily> GetItemFamilyById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var itemFamily = await client.GetAsync<ItemFamily>("itemFamilies/" + id);
				return itemFamily;
			}
		}

		public async Task<ItemFamily> CreateItemFamily(ItemFamily itemFamily)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<ItemFamily, ItemFamily>("itemFamilies/", itemFamily);
				return response;
			}
		}

		public async Task UpdateItemFamily(ItemFamily itemFamily)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<ItemFamily, int>("itemFamilies/" + itemFamily.Id, itemFamily);
			}
		}

		public async Task DeleteItemFamily(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("itemFamilies/" + id);
			}
		}
	}
}
