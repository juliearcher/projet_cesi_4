using API.Models;

namespace API.Data
{
	public interface ICustomerRepository : IBaseRepository<Customer> { }
	public interface IInventoryRepository : IBaseRepository<Inventory> { }
	public interface IInventoryLineRepository : IBaseRepository<InventoryLine> { }
	public interface IItemRepository : IBaseRepository<Item> { }
	public interface IItemFamilyRepository : IBaseRepository<ItemFamily> { }
	public interface IOrderRepository : IBaseRepository<Order> { }
	public interface IOrderLineRepository : IBaseRepository<OrderLine> { }
	public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder> { }
	public interface IPurchaseOrderLineRepository : IBaseRepository<PurchaseOrderLine> { }
	public interface ISupplierRepository : IBaseRepository<Supplier> { }
}