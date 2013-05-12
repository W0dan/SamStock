using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Stock.FindMancos {
    public class FindMancosResponse {
        public List<FindMancosItem> List { get; set; }

        public FindMancosResponse() {
            List = new List<FindMancosItem>();
        }
    }

    public class FindMancosItem {
        public string Stocknr { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public int Hoeveelheid { get; set; }

        public int MinimumStock { get; set; }

        public string Opmerkingen { get; set; }

        public string LeverancierNaam { get; set; }
    }
}
