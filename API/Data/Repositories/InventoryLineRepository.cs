using API.Models;

namespace API.Data
{
	public class InventoryLineRepository : BaseRepository<InventoryLine>, IInventoryLineRepository
	{
		public InventoryLineRepository(ApiContext context) : base(context)
		{

		}
	}
}