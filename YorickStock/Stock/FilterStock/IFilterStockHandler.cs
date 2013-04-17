using SamStock.Utilities;

namespace SamStock.Stock.FilterStock {
    public interface IFilterStockHandler : IQueryHandler<FilterStockRequest, FilterStockResponse> {
    }
}
