using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.UpdatePedalComponents {
    public class UpdatePedalComponentsCommand {
        public int Id { get; private set;}
        public int ComponentId { get; private set;}
        public int Quantity { get; private set;}

        public UpdatePedalComponentsCommand(int id, int componentid, int quantity)
        {
            Id = id;
            ComponentId = componentid;
            Quantity = quantity;
        }
    }
}
