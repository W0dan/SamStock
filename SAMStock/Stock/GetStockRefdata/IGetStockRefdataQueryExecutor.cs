using SAMStock.Utilities;

namespace SAMStock.Stock.GetStockRefdata
{
    public interface IGetStockRefdataQueryExecutor : IQuery
    {
        GetStockRefdataResponse Execute(GetStockRefdataRequest request);
    }
}