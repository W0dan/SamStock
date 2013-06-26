using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Stock.FilterStock
{
	public class FilterStockHandler : IFilterStockHandler
	{
		private readonly IFilterStockQueryExecutor _filterStockQueryExecutor;

		public FilterStockHandler(IFilterStockQueryExecutor filterStockQueryExecutor)
		{
			_filterStockQueryExecutor = filterStockQueryExecutor;
		}

		public FilterStockResponse Handle(FilterStockRequest request)
		{
			return _filterStockQueryExecutor.Execute(request);
		}
	}
}
