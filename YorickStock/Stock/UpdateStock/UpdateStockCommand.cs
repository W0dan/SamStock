using System.Collections.Generic;

namespace SamStock.Stock.UpdateStock
{
    public class UpdateStockCommand
    {
        public List<StockUpdate> List { get; set; }
    }

    public class StockUpdate
    {
        public StockUpdate(string stocknr, int amount)
        {
            Stocknr = stocknr;
            Amount = amount;
        }

        public string Stocknr { get; private set; }

        public int Amount { get; private set; }
    }
}