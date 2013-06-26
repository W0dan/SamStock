using System.Collections.Generic;

namespace SamStock.Web.Models.Stock
{
    public class StockChangesViewModel
    {
        public IEnumerable<StockChange> List { get; set; } 
    }
}