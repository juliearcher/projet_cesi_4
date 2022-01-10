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
	public class PurchaseOrderService : IPurchaseOrderService
	{
		public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrders()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var purchaseOrderList = await client.GetAsync<IEnumerable<PurchaseOrder>>("purchaseOrders");
				return purchaseOrderList;
			}
		}

		public async Task<PurchaseOrder> GetPurchaseOrderById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var purchaseOrder = await client.GetAsync<PurchaseOrder>("purchaseOrders/" + id);
				return purchaseOrder;
			}
		}

		public async Task<PurchaseOrder> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<PurchaseOrder, PurchaseOrder>("purchaseOrders/", purchaseOrder);
				return response;
			}
		}

		public async Task UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<PurchaseOrder, int>("purchaseOrders/" + purchaseOrder.Id, purchaseOrder);
			}
		}

		public async Task DeletePurchaseOrder(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("purchaseOrders/" + id);
			}
		}

		public async Task SetPurchaseOrderToReceived(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var patchDoc = new JsonPatchDocument<PurchaseOrder>().Replace(o => o.DocumentState, (int)IPurchaseOrder.PurchaseOrderState.Received);

				var content = new StringContent(JsonConvert.SerializeObject(patchDoc), Encoding.UTF8, "application/json-patch+json");
				await client.CustomPatchAsync("purchaseOrders/" + id, content);
			}
		}
	}
}
