using System.Collections.Generic;

namespace SamStock.Stock.UpdateStock
{
    public class UpdateStockCommand
    {
        public List<StockUpdate> List { get; set; }
    }

    public class StockUpdate
    {
        public StockUpdate(string stocknr, int amount, decimal price)
        {
            Stocknr = stocknr;
            Quantity = amount;
            Price = price;
        }

        public string Stocknr { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }
    }
}