using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Stock.FilterStock {
    public class FilterStockRequest {
        private readonly string _componentType;
        private readonly int _leverancierID;

        public FilterStockRequest(string componentType, int leverancierID) {
            _componentType = componentType;
            _leverancierID = leverancierID;
        }
        public string ComponentType { get { return _componentType; } }
        public int LeverancierID { get { return _leverancierID; } }
    }
}
