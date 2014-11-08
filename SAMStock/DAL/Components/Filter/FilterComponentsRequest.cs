using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsRequest: Request<FilterComponentsResponse>
	{
		public FilterComponentsRequest(object s) : base(s)
		{
		}

		public int? Id { get; set; }
		public int? PedalId { get; set; }
		public int? StockLowerThan { get; set; }
		public int? StockHigherThan { get; set; }
		public bool? Shortage { get; set; }
		public int? SupplierId { get; set; }
	}
}