using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface IPurchaseOrderService
	{
		Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrders();
		Task<PurchaseOrder> GetPurchaseOrderById(long id);
		Task<PurchaseOrder> CreatePurchaseOrder(PurchaseOrder purchaseOrder);
		Task UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
		Task DeletePurchaseOrder(long id);
		Task SetPurchaseOrderToReceived(long id);
	}
}
