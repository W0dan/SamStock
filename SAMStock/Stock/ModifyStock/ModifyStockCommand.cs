using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Stock.ModifyStock
{
	public class ModifyStockCommand
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Quantity { get; private set; }
		public string Stocknr { get; private set; }
		public decimal Price { get; private set; }
		public string SupplierName { get; private set; }
		public string Remarks { get; private set; }
		public string ItemCode { get; private set; }
		public bool DeleteOption {get; private set; }

		public ModifyStockCommand(int id, string name, int minimumstock, int quantity, string stocknr, decimal price, string suppliername, string remarks, string itemcode, bool deleteoption)
		{
			Id = id;
			Name = name;
			MinimumStock = minimumstock;
			Quantity = quantity;
			Stocknr = stocknr;
			Price = price;
			SupplierName = suppliername;
			Remarks = remarks;
			ItemCode = itemcode;
			DeleteOption = deleteoption;
		}

		public ModifyStockCommand(int id, bool deleteoption)
		{
			Id = id;
			DeleteOption = deleteoption;
		}
	}
}
