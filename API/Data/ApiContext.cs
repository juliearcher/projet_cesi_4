using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API.Data
{
	public class ApiContext : DbContext
	{
		public ApiContext(DbContextOptions<ApiContext> opt) : base(opt)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.HasIndex(customer => new { customer.Code }).IsUnique(true);
			});

			modelBuilder.Entity<Inventory>(entity =>
			{
				entity.HasIndex(inventory => new { inventory.DocumentNumber }).IsUnique(true);
			});

			modelBuilder.Entity<InventoryLine>(entity =>
			{
				entity.HasIndex(inventoryLine => new { inventoryLine.InventoryId, inventoryLine.LineOrder }).IsUnique(true);
			});

			modelBuilder.Entity<Item>(entity =>
			{
				entity.HasIndex(item => new { item.Code }).IsUnique(true);
				entity.Property(e => e.RealStock).HasDefaultValue(0).ValueGeneratedOnAdd();
				entity.Property(e => e.VirtualStock).HasDefaultValue(0).ValueGeneratedOnAdd();
				entity.Property(e => e.SalePrice).HasDefaultValue(0).ValueGeneratedOnAdd();
				entity.Property(e => e.PurchasePrice).HasDefaultValue(0).ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<ItemFamily>(entity =>
			{
				entity.HasIndex(itemFamily => new { itemFamily.Code }).IsUnique(true);
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.HasIndex(order => new { order.DocumentNumber }).IsUnique(true);
				entity.Property(e => e.DiscountRate).HasDefaultValue(0).ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<OrderLine>(entity =>
			{
				entity.HasIndex(orderLine => new { orderLine.OrderId, orderLine.LineOrder }).IsUnique(true);
				entity.Property(e => e.DiscountRate).HasDefaultValue(0).ValueGeneratedOnAdd();
				entity.Property(e => e.Quantity).HasDefaultValue(0).ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<PurchaseOrder>(entity =>
			{
				entity.HasIndex(purchaseOrder => new { purchaseOrder.DocumentNumber }).IsUnique(true);
				entity.Property(e => e.DiscountRate).HasDefaultValue(0).ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<PurchaseOrderLine>(entity =>
			{
				entity.HasIndex(purchaseOrderLine => new { purchaseOrderLine.PurchaseOrderId, purchaseOrderLine.LineOrder }).IsUnique(true);
				entity.Property(e => e.DiscountRate).HasDefaultValue(0).ValueGeneratedOnAdd();
				entity.Property(e => e.Quantity).HasDefaultValue(0).ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<Supplier>(entity =>
			{
				entity.HasIndex(supplier => new { supplier.Code }).IsUnique(true);
			});
		}

		public override int SaveChanges()
		{
			var entries = ChangeTracker.Entries()
				.Where(e => e.Entity is BaseModel && (
				e.State == EntityState.Added
				|| e.State == EntityState.Modified));

			foreach (var entityEntry in entries)
			{
				((BaseModel)entityEntry.Entity).SysModifiedDate = DateTime.Now;

				if (entityEntry.State == EntityState.Added)
				{
					((BaseModel)entityEntry.Entity).SysCreatedDate = DateTime.Now;
				}
			}
			return base.SaveChanges();
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<InventoryLine> InventoryLines {get; set;}
		public DbSet<Item> Items { get; set; }
		public DbSet<ItemFamily> ItemFamilies { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
		public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
	}

}