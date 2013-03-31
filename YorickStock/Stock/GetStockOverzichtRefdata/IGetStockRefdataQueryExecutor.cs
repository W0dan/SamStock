namespace SamStock.Stock.GetStockOverzichtRefdata
{
    public interface IGetStockRefdataQueryExecutor
    {
        GetStockRefdataResponse Execute(GetStockRefdataRequest request);
    }
}