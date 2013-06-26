namespace SamStock.Web.Models.Stock
{
    public class StockViewModelNewItem
    {
        public string Stocknr { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int MinimumStock { get; set; }

        public string Remarks { get; set; }

        public int SupplierId { get; set; }

		public string ItemCode { get; set; }
	}
}