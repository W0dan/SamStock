namespace SAMStock.DTO.Component.FilterComponent
{
	public class FilterComponentHandler: RequestHandler<FilterComponentRequest, FilterComponentResponse>
	{
		public FilterComponentHandler(IRequestExecutor<FilterComponentRequest, FilterComponentResponse> filterStockRequestExecutorExecutor): base(filterStockRequestExecutorExecutor)
		{
		}
	}
}
