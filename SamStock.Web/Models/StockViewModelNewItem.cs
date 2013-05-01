namespace SamStock.Web.Models
{
    public class StockViewModelNewItem
    {
        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public int Hoeveelheid { get; set; }

        public int MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public int LeverancierId { get; set; }
    }
}