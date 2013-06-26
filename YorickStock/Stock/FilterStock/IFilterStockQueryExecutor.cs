using SamStock.Utilities;

namespace SamStock.Stock.FilterStock
{
	public interface IFilterStockQueryExecutor : IQuery
	{
		FilterStockResponse Execute(FilterStockRequest request);
	}
}
