using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
    public class ComponentOrderDeliveryComponent: IBO
    {
        public int Id { get; private set; }
        public Component Component { get; private set; }
        public int Amount { get; private set; }

        public ComponentOrderDeliveryComponent(Database.ComponentsOfComponentOrderDelivery component)
        {
            Component = new Component(component.Component);
            Amount = component.Amount;
            Id = component.Id;
        }
    }
}
