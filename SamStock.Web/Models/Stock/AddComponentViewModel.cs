using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Stock.GetStockRefdata;

namespace SamStock.Web.Models.Stock
{
	public class AddComponentViewModel
	{
		public string Stocknr { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int MinimumStock { get; set; }
		public string Remarks { get; set; }
		public int SupplierId { get; set; }
		public string ItemCode { get; set; }
		public List<StockViewModelSupplier> Suppliers {get; private set;}

		public AddComponentViewModel(GetStockRefdataResponse refdata)
		{
			Suppliers = new List<StockViewModelSupplier>();

			foreach (var leverancier in refdata.Suppliers)
			{
				Suppliers.Add(new StockViewModelSupplier(leverancier));
			}
		}
	}
}