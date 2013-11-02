using System.Collections.Generic;

namespace SAMStock.Web.Models.Stock
{
    public class StockChangesViewModel
    {
        public IEnumerable<StockChange> StockChanges { get; set; } 
    }
}