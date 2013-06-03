﻿namespace SamStock.Stock.GetStockRefdata
{
    public class GetStockRefdataHandler : IGetStockRefdataHandler
    {
        private readonly IGetStockRefdataQueryExecutor _getStockRefdataQueryExecutor;

        public GetStockRefdataHandler(IGetStockRefdataQueryExecutor getStockRefdataQueryExecutor)
        {
            _getStockRefdataQueryExecutor = getStockRefdataQueryExecutor;
        }

        public GetStockRefdataResponse Handle(GetStockRefdataRequest request)
        {
            return _getStockRefdataQueryExecutor.Execute(request);
        }
    }
}