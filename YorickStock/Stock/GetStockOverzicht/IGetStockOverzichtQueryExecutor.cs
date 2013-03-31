namespace SamStock.Stock.GetStockOverzicht
{
    public interface IGetStockOverzichtQueryExecutor
    {
        GetStockOverzichtResponse Execute(GetStockOverzichtQuery query);
    }
}