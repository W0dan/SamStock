using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsHandler : RequestHandler<FilterPedalsRequest, FilterPedalsResponse>
	{
		public FilterPedalsHandler(IRequestExecutor<FilterPedalsRequest, FilterPedalsResponse> executor) : base(executor)
		{
		}
	}
}
