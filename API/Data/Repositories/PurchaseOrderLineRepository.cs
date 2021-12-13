using API.Models;

namespace API.Data
{
	public class PurchaseOrderLineRepository : BaseRepository<PurchaseOrderLine>, IPurchaseOrderLineRepository
	{
		public PurchaseOrderLineRepository(ApiContext context) : base(context)
		{

		}
	}
}