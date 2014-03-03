using System.Collections.Generic;

namespace SAMStock.DAL.Component.FilterComponent
{
	public class FilterComponentResponseItem
	{
		public string Stocknr { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int MinimumStock { get; set; }
		public string Remark { get; set; }
		public int Id { get; set; }
		public string ItemCode { get; set; }
		public List<int> PedalIds { get; set; }
		public int SupplierId { get; set; }
	}
}
