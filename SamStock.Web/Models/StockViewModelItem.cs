using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.FindMancos;

namespace SamStock.Web.Models
{
    public class StockViewModelItem
    {
        public StockViewModelItem()
        {

        }

        public StockViewModelItem(GetStockOverzichtItem item)
        {
            Stocknr = item.Stocknr;
            Naam = item.Naam;
            Prijs = item.Prijs;
            Hoeveelheid = item.Hoeveelheid;
            MinimumStock = item.MinimumStock;
            Opmerkingen = item.Opmerkingen;
            LeverancierNaam = item.LeverancierNaam;
        }

        public StockViewModelItem(FilterStockItem item)
        {
            Stocknr = item.Stocknr;
            Naam = item.Naam;
            Prijs = item.Prijs;
            Hoeveelheid = item.Hoeveelheid;
            MinimumStock = item.MinimumStock;
            Opmerkingen = item.Opmerkingen;
            LeverancierNaam = item.LeverancierNaam;
        }

        public StockViewModelItem(FindMancosItem item) {
            Stocknr = item.Stocknr;
            Naam = item.Naam;
            Prijs = item.Prijs;
            Hoeveelheid = item.Hoeveelheid;
            MinimumStock = item.MinimumStock;
            Opmerkingen = item.Opmerkingen;
            LeverancierNaam = item.LeverancierNaam;
        }

        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public int Hoeveelheid { get; set; }

        public int MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public string LeverancierNaam { get; set; }
    }
}