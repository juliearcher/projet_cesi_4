using API.Models;

namespace API.Data
{
	public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(ApiContext context) : base(context)
		{

		}
	}
}