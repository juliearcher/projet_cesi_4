using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class ApiServicesCollection : IApiServicesCollection
	{
		public ICustomerService CustomerService { get; }
		public IInventoryService InventoryService { get; }
		public IItemFamilyService ItemFamilyService { get; }
		public IItemService ItemService { get; }
		public IOrderService OrderService { get; }
		public IPurchaseOrderService PurchaseOrderService { get; }
		public ISupplierService SupplierService { get; }

		public ApiServicesCollection(ICustomerService customerService, IInventoryService inventoryService,
			IItemFamilyService itemFamilyService, IItemService itemService, IOrderService orderService,
			IPurchaseOrderService purchaseOrderService, ISupplierService supplierService)
		{
			CustomerService = customerService;
			InventoryService = inventoryService;
			ItemFamilyService = itemFamilyService;
			ItemService = itemService;
			OrderService = orderService;
			PurchaseOrderService = purchaseOrderService;
			SupplierService = supplierService;
		}
	}
}
