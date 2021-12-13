using API.Models;

namespace API.Data
{
	public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
	{
		public SupplierRepository(ApiContext context) : base(context)
		{

		}
	}
}