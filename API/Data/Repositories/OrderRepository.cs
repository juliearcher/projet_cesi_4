using API.Models;

namespace API.Data
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(ApiContext context) : base(context)
		{

		}
	}
}