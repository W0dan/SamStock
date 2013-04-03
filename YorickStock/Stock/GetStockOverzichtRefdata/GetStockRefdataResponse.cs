using System.Collections.Generic;

namespace SamStock.Stock.GetStockOverzichtRefdata
{
    public class GetStockRefdataResponse
    {
        public IEnumerable<LeverancierRefdata> Leveranciers { get; set; }
    }

    public class LeverancierRefdata
    {
        public int Id { get; set; }
        public string Naam { get; set; }
    }
}