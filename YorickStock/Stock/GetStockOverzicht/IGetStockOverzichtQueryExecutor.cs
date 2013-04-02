using SamStock.Utilities;

namespace SamStock.Stock.GetStockOverzicht
{
    public interface IGetStockOverzichtQueryExecutor:IQuery
    {
        GetStockOverzichtResponse Execute(GetStockOverzichtRequest request);
    }
}