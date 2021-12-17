using API.Models;

namespace API.Data
{
	public class ItemRepository : BaseRepository<Item>, IItemRepository
	{
		public ItemRepository(ApiContext context) : base(context)
		{

		}
	}
}