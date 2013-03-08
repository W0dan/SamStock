namespace YorickStock.GetStockOverzicht
{
    public class GetStockOverzichtHandler
    {
        private readonly IGetStockOverzichtQueryExecutor _getStockOverzichtQueryExecutor;

        public GetStockOverzichtHandler(IGetStockOverzichtQueryExecutor getStockOverzichtQueryExecutor)
        {
            _getStockOverzichtQueryExecutor = getStockOverzichtQueryExecutor;
        }

        public GetStockOverzichtResponse Handle(GetStockOverzichtQuery query)
        {
            return _getStockOverzichtQueryExecutor.Execute(query);
        }
    }
}