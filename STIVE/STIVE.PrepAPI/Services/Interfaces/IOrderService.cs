using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetAllOrders();
		Task<Order> GetOrderById(long id);
		Task<Order> CreateOrder(Order order);
		Task UpdateOrder(Order order);
		Task DeleteOrder(long id);
	}
}
