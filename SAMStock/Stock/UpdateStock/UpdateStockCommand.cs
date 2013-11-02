using System.Collections.Generic;

namespace SAMStock.Stock.UpdateStock
{
    public class UpdateStockCommand
    {
        public List<StockUpdate> StockUpdates { get; set; }
    }
}