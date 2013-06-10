using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;
using SamStock.Stock.FilterStock;

namespace SamStock.Web.Models {
    public class PedalUpdateComponentsViewModel {
        public int Id {get; private set;}
        public List<FilterPedalResponseComponent> List {get; private set;}
        // public List<FilterStockItem> Stock;

        public PedalUpdateComponentsViewModel(int id, List<FilterPedalResponseComponent> complist/*, List<FilterStockItem> stock*/) {
            Id = id;
            List = complist;
            // Stock = stock;
        }
    }
}