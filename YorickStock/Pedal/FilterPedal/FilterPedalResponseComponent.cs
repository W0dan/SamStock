﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.FilterPedal {
    public class FilterPedalResponseComponent {
        public String Stocknr { get; set;}
        public String Description { get; set; }
        public int Count { get; set;}
        public decimal Price { get; set;}
    }
}