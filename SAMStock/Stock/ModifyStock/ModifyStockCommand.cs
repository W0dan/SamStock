using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Stock.ModifyStock
{
	public class ModifyStockCommand
	{
		public int Id { get; private set; }
		public String Name { get; private set; }
		public int MinimumStock { get; private set; }
		public int Quantity { get; private set; }
		public String Stocknr { get; private set; }
		public decimal Price { get; private set; }
		public string SupplierName { get; private set; }
		public String Remarks { get; private set; }
		public String ItemCode { get; private set; }
		public Boolean DeleteOption {get; private set; }

		public ModifyStockCommand(int id, String name, int minimumstock, int quantity, String stocknr, decimal price, string suppliername, String remarks, String itemcode, Boolean deleteoption)
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
	}
}
