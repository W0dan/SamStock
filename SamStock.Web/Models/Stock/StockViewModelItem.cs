using SAMStock.Stock.FilterStock;

namespace SAMStock.Web.Models.Stock
{
    public class StockViewModelItem
    {
        public StockViewModelItem()
        {
        }

        public StockViewModelItem(FilterStockItem item)
        {
            Stocknr = item.Stocknr;
            Name = item.Name;
            Price = item.Price;
            Quantity = item.Quantity;
            MinimumStock = item.MinimumStock;
            Remarks = item.Remark;
            SupplierName = item.SupplierName;
			ItemCode = item.ItemCode;
        }

        public string Stocknr { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int MinimumStock { get; set; }

        public string Remarks { get; set; }

        public string SupplierName { get; set; }

		public string ItemCode { get; set; }
    }
}