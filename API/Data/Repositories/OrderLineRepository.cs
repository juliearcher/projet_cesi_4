using API.Models;

namespace API.Data
{
	public class OrderLineRepository : BaseRepository<OrderLine>, IOrderLineRepository
	{
		public OrderLineRepository(ApiContext context) : base(context)
		{

		}
	}
}