using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Stock.FilterStock;

namespace SamStock.Web.Models.Stock
{
	public class StockModifyComponentViewModel
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public int MinimumStock { get; set; }
		public int Quantity { get; set; }
		public String Stocknr { get; set; }
		public decimal Price { get; set; }
		public string SupplierName { get; set;}
		public String Remarks { get; set; }
		public String ItemCode { get; set; }
		public Boolean DeleteOption {get; set; }

		public StockModifyComponentViewModel()
		{
			Id = 0;
			Name = "";
			MinimumStock = 0;
			Quantity = 0;
			Stocknr = "";
			Price = 0.0M;
			Remarks = "";
			ItemCode = "";
			SupplierName = "";
			DeleteOption = false;
		}

		public StockModifyComponentViewModel(FilterStockItem item)
		{
			Id = item.Id;
			Name = item.Name;
			MinimumStock = item.MinimumStock;
			Quantity = item.Quantity;
			Stocknr = item.Stocknr;
			Price = item.Price;
			Remarks = item.Remark;
			ItemCode = item.ItemCode;
			SupplierName = item.SupplierName;
			DeleteOption = false;
		}
	}
}