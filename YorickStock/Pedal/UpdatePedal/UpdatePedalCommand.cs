using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.UpdatePedal {
    public class UpdatePedalCommand {
        public int Id { get; private set;}
        public String Name { get; private set; }
        public decimal Price {get; private set;}
        public decimal Margin { get; private set;}

        public UpdatePedalCommand(int id, String name, decimal price, decimal margin)
        {
            Id = id;
            Name = name;
            Price = price;
            Margin = margin;
        }
    }
}
