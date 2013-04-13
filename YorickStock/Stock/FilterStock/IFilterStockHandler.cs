using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Stock.FilterStock {
    public interface IFilterStockHandler : IQueryHandler<FilterStockRequest, FilterStockResponse> {
    }
}
