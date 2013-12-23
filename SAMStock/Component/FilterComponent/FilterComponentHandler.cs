using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.FilterComponent
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
