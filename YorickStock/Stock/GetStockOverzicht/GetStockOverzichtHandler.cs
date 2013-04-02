namespace SamStock.Stock.GetStockOverzicht
{
    public class GetStockOverzichtHandler : IGetStockOverzichtHandler
    {
        private readonly IGetStockOverzichtQueryExecutor _getStockOverzichtQueryExecutor;

        public GetStockOverzichtHandler(IGetStockOverzichtQueryExecutor getStockOverzichtQueryExecutor)
        {
            _getStockOverzichtQueryExecutor = getStockOverzichtQueryExecutor;
        }

        public GetStockOverzichtResponse Handle(GetStockOverzichtRequest request)
        {
            return _getStockOverzichtQueryExecutor.Execute(request);
        }
    }
}