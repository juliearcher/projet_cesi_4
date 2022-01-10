using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface IInventoryService
	{
		Task<IEnumerable<Inventory>> GetAllInventories();
		Task<Inventory> GetInventoryById(long id);
		Task<Inventory> CreateInventory(Inventory inventory);
		Task UpdateInventory(Inventory inventory);
		Task DeleteInventory(long id);
		Task SetInventoryToValidated(long id);
	}
}
