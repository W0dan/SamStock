using System.Collections.Generic;

namespace SAMStock.Stock.FilterStock
{
	public class FilterStockResponse
	{
		public FilterStockResponse()
		{
			Components = new List<FilterStockItem>();
		}

		public List<FilterStockItem> Components { get; set; }
	}
}
