namespace SAMStock.Component.FilterComponent
{
	public class FilterComponentRequest
	{
		public string StockNr { get; set; }
		public int? SupplierId { get; set; }
		public int? ComponentId { get; set; }
		private bool _shortage = false;
		public bool Shortage {get { return _shortage; } set { _shortage = value; }}
	}
}
