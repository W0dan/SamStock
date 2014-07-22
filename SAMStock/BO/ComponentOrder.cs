using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
	public class ComponentOrder : Base.BOBase
    {
        public Dictionary<Component, int> Components { get; private set; }
        public DateTime DateCreated { get; private set; }

        public ComponentOrder(Database.ComponentOrder order)
        {
	        Components = order.ComponentsOfComponentOrders.ToDictionary(x => new Component(x.Component), x => x.Amount);
            DateCreated = order.DateCreated;
            Id = order.Id;
        }
    }
}
