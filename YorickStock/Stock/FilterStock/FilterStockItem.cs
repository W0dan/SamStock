using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Stock.FilterStock {
    public class FilterStockItem {
        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public int Hoeveelheid { get; set; }

        public int MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public string LeverancierNaam { get; set; }

        public int Id { get; set; }
    }
}
