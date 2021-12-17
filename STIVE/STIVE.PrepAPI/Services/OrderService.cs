using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class OrderService : IOrderService
	{
		public async Task<IEnumerable<Order>> GetAllOrders()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var orderList = await client.GetAsync<IEnumerable<Order>>("orders");
				return orderList;
			}
		}

		public async Task<Order> GetOrderById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var order = await client.GetAsync<Order>("orders/" + id);
				return order;
			}
		}

		public async Task<Order> CreateOrder(Order order)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<Order, Order>("orders/", order);
				return response;
			}
		}

		public async Task UpdateOrder(Order order)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<Order, int>("orders/" + order.Id, order);
			}
		}

		public async Task DeleteOrder(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("orders/" + id);
			}
		}
	}
}
