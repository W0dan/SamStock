using System.Collections.Generic;

namespace SamStock.Stock.FilterStock {
    public class FilterStockResponse {
        public FilterStockResponse() {
            List = new List<FilterStockItem>();
        }

        public List<FilterStockItem> List { get; set; }
    }
}
