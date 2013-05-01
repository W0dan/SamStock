using System.Collections.Generic;

namespace SamStock.Web.Models
{
    public class StockChangesViewModel
    {
        public IEnumerable<StockChange> List { get; set; } 
    }
}