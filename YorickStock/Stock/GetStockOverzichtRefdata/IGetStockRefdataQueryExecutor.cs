using SamStock.Utilities;

namespace SamStock.Stock.GetStockOverzichtRefdata
{
    public interface IGetStockRefdataQueryExecutor : IQuery
    {
        GetStockRefdataResponse Execute(GetStockRefdataRequest request);
    }
}