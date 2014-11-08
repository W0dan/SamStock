using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsRequest: Request<FilterPedalsResponse>
	{
		public FilterPedalsRequest(object s) : base(s)
		{
		}

		public int? Id { get; set; }
		public int? ComponentId { get; set; }
	}
}
