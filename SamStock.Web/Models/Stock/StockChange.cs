namespace SamStock.Web.Models.Stock
{
	public class StockChange
	{
		public string Stocknr { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}