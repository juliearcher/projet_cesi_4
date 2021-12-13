using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<Customer>> GetAllCustomers();
		Task<Customer> GetCustomerById(long id);
		Task<Customer> CreateCustomer(Customer customer);
		Task UpdateCustomer(Customer customer);
		Task DeleteCustomer(long id);
	}
}
