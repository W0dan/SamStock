using System.Collections.Generic;

namespace SamStock.Web.Models.Stock
{
    public class StockChangesViewModel
    {
        public IEnumerable<StockChange> StockChanges { get; set; } 
    }
}