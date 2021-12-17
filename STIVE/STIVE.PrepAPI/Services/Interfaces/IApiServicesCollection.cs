using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface IApiServicesCollection
	{
		public ICustomerService CustomerService { get; }
		public IInventoryService InventoryService { get; }
		public IItemFamilyService ItemFamilyService { get; }
		public IItemService ItemService { get; }
		public IOrderService OrderService { get; }
		public IPurchaseOrderService PurchaseOrderService { get; }
		public ISupplierService SupplierService { get; }
	}
}
