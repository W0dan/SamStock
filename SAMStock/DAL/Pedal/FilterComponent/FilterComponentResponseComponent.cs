using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Pedal.FilterComponent
{
	public class FilterComponentResponseComponent
	{
		public string Stocknr { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int MinimumStock { get; set; }
		public string Remark { get; set; }
		public int Id { get; set; }
		public string ItemCode { get; set; }
		public int SupplierId { get; set; }
		public int Quantity { get; set; }
	}
}
