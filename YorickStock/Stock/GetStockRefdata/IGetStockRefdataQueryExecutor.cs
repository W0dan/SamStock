using SamStock.Utilities;

namespace SamStock.Stock.GetStockRefdata
{
    public interface IGetStockRefdataQueryExecutor : IQuery
    {
        GetStockRefdataResponse Execute(GetStockRefdataRequest request);
    }
}