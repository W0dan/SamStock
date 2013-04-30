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
}