using API.Models;

namespace API.Data
{
	public class ItemFamilyRepository : BaseRepository<ItemFamily>, IItemFamilyRepository
	{
		public ItemFamilyRepository(ApiContext context) : base(context)
		{

		}
	}
}