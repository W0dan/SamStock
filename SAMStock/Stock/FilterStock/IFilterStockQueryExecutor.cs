using SAMStock.Utilities;

namespace SAMStock.Stock.FilterStock
{
	public interface IFilterStockQueryExecutor : IQuery
	{
		FilterStockResponse Execute(FilterStockRequest request);
	}
}
