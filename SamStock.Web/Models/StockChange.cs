namespace SamStock.Web.Models
{
    public class StockChange
    {
        public string Stocknr { get; set; }
        public int Amount { get; set; }
        public decimal Prijs { get; set; }
    }
}