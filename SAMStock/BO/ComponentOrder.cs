using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
    public class ComponentOrder: IBO
    {
        public List<ComponentOrderComponent> Components { get; private set; }
        public DateTime DateCreated { get; private set; }
        public int Id { get; private set; }

        public ComponentOrder(Database.ComponentOrder order)
        {
            Components = order.ComponentsOfComponentOrders.Select(x => new ComponentOrderComponent(x)).ToList();
            DateCreated = order.DateCreated;
            Id = order.Id;
        }
    }
}
