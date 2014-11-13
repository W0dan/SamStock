using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsHandler : Handler<FilterPedalsRequest, FilterPedalsResponse>
	{
		public FilterPedalsHandler(IExecutor<FilterPedalsRequest, FilterPedalsResponse> executor) : base(executor)
		{
		}
	}
}
