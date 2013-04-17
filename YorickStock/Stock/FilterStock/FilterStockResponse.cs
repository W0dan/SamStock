using System.Collections.Generic;

namespace SamStock.Stock.FilterStock {
    public class FilterStockResponse {
        public FilterStockResponse() {
            List = new List<FilterStockItem>();
        }

        public List<FilterStockItem> List { get; set; }
    }

    public class FilterStockItem {
        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public int Hoeveelheid { get; set; }

        public int MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public string LeverancierNaam { get; set; }
    }
}
