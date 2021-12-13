using API.Data;

namespace API.Configuration
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly ApiContext _context;

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

		public UnitOfWork(ApiContext context, ICustomerRepository customerRepository,
			IInventoryRepository inventoryRepository, IInventoryLineRepository inventoryLineRepository,
			IItemRepository itemRepository, IItemFamilyRepository itemFamilyRepository,
			IOrderRepository orderRepository, IOrderLineRepository orderLineRepository,
			IPurchaseOrderRepository purchaseOrderRepository,
			IPurchaseOrderLineRepository purchaseOrderLineRepository, ISupplierRepository supplierRepository)
		{
			_context = context;
			CustomerRepository = customerRepository;
			InventoryRepository = inventoryRepository;
			InventoryLineRepository = inventoryLineRepository;
			ItemRepository = itemRepository;
			ItemFamilyRepository = itemFamilyRepository;
			OrderRepository = orderRepository;
			OrderLineRepository = orderLineRepository;
			PurchaseOrderRepository = purchaseOrderRepository;
			PurchaseOrderLineRepository = purchaseOrderLineRepository;
			SupplierRepository = supplierRepository;
		}

		public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}