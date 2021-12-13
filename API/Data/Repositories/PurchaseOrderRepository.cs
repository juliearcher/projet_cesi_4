using API.Models;

namespace API.Data
{
	public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
	{
		public PurchaseOrderRepository(ApiContext context) : base(context)
		{

		}
	}
}