namespace YorickStock.GetStockOverzicht
{
    public interface IGetStockOverzichtQueryExecutor
    {
        GetStockOverzichtResponse Execute(GetStockOverzichtQuery query);
    }
}