using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.UpdateStock
{
	public class UpdateStockCommand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? MinimumStock { get; set; }
		public int? Quantity { get; set; }
		public string Stocknr { get; set; }
		public decimal? Price { get; set; }
		public int? SupplierId { get; set; }
		public string Remarks { get; set; }
		public string ItemCode { get; set; }
	}
}
