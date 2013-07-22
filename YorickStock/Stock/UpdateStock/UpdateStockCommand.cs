using System.Collections.Generic;

namespace SamStock.Stock.UpdateStock
{
    public class UpdateStockCommand
    {
        public List<StockUpdate> StockUpdates { get; set; }
    }
}