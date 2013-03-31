using System.Collections.Generic;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;

namespace SamStock.Web.Models
{
    public class StockViewModel
    {
        public StockViewModel(IEnumerable<GetStockOverzichtItem> list, GetStockRefdataResponse refdata)
        {
            List = new List<StockViewModelItem>();
            Leveranciers = new List<StockViewModelLeverancier>();

            foreach (var item in list)
            {
                List.Add(new StockViewModelItem(item));
            }

            foreach (var leverancier in refdata.List)
            {
                Leveranciers.Add(new StockViewModelLeverancier(leverancier));
            }
        }

        public List<StockViewModelItem> List { get; private set; }

        public List<StockViewModelLeverancier> Leveranciers { get; private set; }
    }

    public class StockViewModelLeverancier
    {
        public StockViewModelLeverancier(LeverancierRefdata leverancier)
        {
            Id = leverancier.Id;
            Naam = leverancier.Naam;
        }

        public string Naam { get; set; }

        public int Id { get; set; }
    }

    public class StockViewModelItem
    {
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

        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public decimal Hoeveelheid { get; set; }

        public decimal MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public string LeverancierNaam { get; set; }
    }
}