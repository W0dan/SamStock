using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsHandler : RequestHandler<FilterComponentsRequest, FilterComponentsResponse>
	{
		public FilterComponentsHandler(IRequestExecutor<FilterComponentsRequest, FilterComponentsResponse> executor) : base(executor)
		{
		}
	}
}
