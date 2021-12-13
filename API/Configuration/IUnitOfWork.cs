using API.Data;

namespace API.Configuration
{
	public interface IUnitOfWork
	{
		public ICustomerRepository CustomerRepository { get; }
		public IInventoryRepository InventoryRepository { get; }
		public IInventoryLineRepository InventoryLineRepository { get; }
		public IItemRepository ItemRepository { get; }
		public IItemFamilyRepository ItemFamilyRepository { get; }
		public IOrderRepository OrderRepository { get; }
		public IOrderLineRepository OrderLineRepository { get; }
		public IPurchaseOrderRepository PurchaseOrderRepository { get; }
		public IPurchaseOrderLineRepository PurchaseOrderLineRepository { get; }
		public ISupplierRepository SupplierRepository { get; }

		void SaveChanges();
		void Dispose();
	}
}