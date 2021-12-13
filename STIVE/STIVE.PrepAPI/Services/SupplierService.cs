using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class SupplierService : ISupplierService
	{
		public async Task<IEnumerable<Supplier>> GetAllSuppliers()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var supplierList = await client.GetAsync<IEnumerable<Supplier>>("suppliers");
				return supplierList;
			}
		}

		public async Task<Supplier> GetSupplierById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var supplier = await client.GetAsync<Supplier>("suppliers/" + id);
				return supplier;
			}
		}

		public async Task<Supplier> CreateSupplier(Supplier supplier)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<Supplier, Supplier>("suppliers/", supplier);
				return response;
			}
		}

		public async Task UpdateSupplier(Supplier supplier)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<Supplier, int>("suppliers/" + supplier.Id, supplier);
			}
		}

		public async Task DeleteSupplier(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("suppliers/" + id);
			}
		}
	}
}
