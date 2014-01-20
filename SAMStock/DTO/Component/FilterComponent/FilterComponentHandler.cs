namespace SAMStock.DTO.Component.FilterComponent
{
	public class FilterComponentHandler: IFilterComponentHandler
	{
		private readonly IFilterComponentQueryExecutor _filterStockQueryExecutor;

		public FilterComponentHandler(IFilterComponentQueryExecutor filterStockQueryExecutor)
		{
			_filterStockQueryExecutor = filterStockQueryExecutor;
		}

		public FilterComponentResponse Handle(FilterComponentRequest request)
		{
			return _filterStockQueryExecutor.Execute(request);
		}
	}
}
