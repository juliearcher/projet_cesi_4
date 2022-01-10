using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class InventoryService : IInventoryService
	{
		public async Task<IEnumerable<Inventory>> GetAllInventories()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var inventoryList = await client.GetAsync<IEnumerable<Inventory>>("inventories");
				return inventoryList;
			}
		}

		public async Task<Inventory> GetInventoryById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var inventory = await client.GetAsync<Inventory>("inventories/" + id);
				return inventory;
			}
		}

		public async Task<Inventory> CreateInventory(Inventory inventory)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<Inventory, Inventory>("inventories/", inventory);
				return response;
			}
		}

		public async Task UpdateInventory(Inventory inventory)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<Inventory, int>("inventories/" + inventory.Id, inventory);
			}
		}

		public async Task DeleteInventory(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("inventories/" + id);
			}
		}

		public async Task SetInventoryToValidated(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var patchDoc = new JsonPatchDocument<Inventory>().Replace(o => o.DocumentState, (int)IInventory.InventoryState.Validated);

				var content = new StringContent(JsonConvert.SerializeObject(patchDoc), Encoding.UTF8, "application/json-patch+json");
				await client.CustomPatchAsync("inventories/" + id, content);
			}
		}
	}
}
