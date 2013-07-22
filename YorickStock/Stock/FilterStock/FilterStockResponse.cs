using System.Collections.Generic;

namespace SamStock.Stock.FilterStock
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
