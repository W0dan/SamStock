namespace SAMStock.DTO.Component.FilterComponent
{
	public class FilterComponentRequest
	{
		public string StockNr { get; set; }
		public int? SupplierId { get; set; }
		public int? ComponentId { get; set; }
		public bool Shortage { get; set; }

		public FilterComponentRequest()
		{
			Shortage = false;
		}
	}
}
