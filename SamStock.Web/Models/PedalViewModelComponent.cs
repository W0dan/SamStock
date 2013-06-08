using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;

namespace SamStock.Web.Models {
    public class PedalViewModelComponent {
        public String Stocknr { get; private set; }
        public String Description { get; private set;}
        public int Count { get; private set; }
        public decimal Price {get; private set; }

        public PedalViewModelComponent(FilterPedalResponseComponent item)
        {
            Stocknr = item.Stocknr;
            Description = item.Description;
            Price = item.Price;
            Count = item.Count;
        }
    }
}