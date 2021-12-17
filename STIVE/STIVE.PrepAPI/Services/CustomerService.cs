using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public class CustomerService : ICustomerService
	{
		public async Task<IEnumerable<Customer>> GetAllCustomers()
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var customerList = await client.GetAsync<IEnumerable<Customer>>("customers");
				return customerList;
			}
		}

		public async Task<Customer> GetCustomerById(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var customer = await client.GetAsync<Customer>("customers/" + id);
				return customer;
			}
		}

		public async Task<Customer> CreateCustomer(Customer customer)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				var response = await client.PostAsync<Customer, Customer>("customers/", customer);
				return response;
			}
		}

		public async Task UpdateCustomer(Customer customer)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.PutAsync<Customer, int>("customers/" + customer.Id, customer);
			}
		}

		public async Task DeleteCustomer(long id)
		{
			using (StiveHttpClient client = new StiveHttpClient())
			{
				await client.CustomDeleteAsync("customers/" + id);
			}
		}
	}
}
