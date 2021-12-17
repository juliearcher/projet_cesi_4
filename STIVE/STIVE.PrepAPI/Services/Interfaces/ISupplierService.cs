using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface ISupplierService
	{
		Task<IEnumerable<Supplier>> GetAllSuppliers();
		Task<Supplier> GetSupplierById(long id);
		Task<Supplier> CreateSupplier(Supplier supplier);
		Task UpdateSupplier(Supplier supplier);
		Task DeleteSupplier(long id);
	}
}
