using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Utilities;

namespace SamStock.Stock.FilterStock {
    public interface IFilterStockQueryExecutor : IQuery {
        FilterStockResponse Execute(FilterStockRequest request);
    }
}
