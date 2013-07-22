using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Stock.UpdateStock
{
	public class StockUpdate
	{
		public string Stocknr { get; private set; }
		public int Quantity { get; private set; }
		public decimal Price { get; private set; }

		public StockUpdate(string stocknr, int amount, decimal price)
		{
			Stocknr = stocknr;
			Quantity = amount;
			Price = price;
		}
	}
}
