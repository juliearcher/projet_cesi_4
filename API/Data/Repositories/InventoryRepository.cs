using API.Models;

namespace API.Data
{
	public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
	{
		public InventoryRepository(ApiContext context) : base(context)
		{

		}
	}
}