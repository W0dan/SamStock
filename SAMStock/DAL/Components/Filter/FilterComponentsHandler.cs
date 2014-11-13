using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Filter
{
	class FilterComponentsHandler : Handler<FilterComponentsRequest, FilterComponentsResponse>
	{
		public FilterComponentsHandler(IExecutor<FilterComponentsRequest, FilterComponentsResponse> executor) : base(executor)
		{
		}
	}
}
