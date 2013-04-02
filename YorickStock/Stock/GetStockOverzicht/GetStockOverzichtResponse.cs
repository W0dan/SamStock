using System.Collections.Generic;

namespace SamStock.Stock.GetStockOverzicht
{
    public class GetStockOverzichtResponse
    {
        public GetStockOverzichtResponse()
        {
            List = new List<GetStockOverzichtItem>();
        }

        public List<GetStockOverzichtItem> List { get; set; }
    }

    public class GetStockOverzichtItem
    {
        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public int Hoeveelheid { get; set; }

        public int MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public string LeverancierNaam { get; set; }
    }
}