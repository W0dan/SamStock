using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.FilterComponent
{
	public class FilterComponentItem
	{
		public string Stocknr { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int MinimumStock { get; set; }
		public string Remark { get; set; }
		public int Id { get; set; }
		public string ItemCode { get; set; }
	}
}
