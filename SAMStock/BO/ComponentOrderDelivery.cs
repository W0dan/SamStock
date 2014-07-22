using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
	public class ComponentOrderDelivery : Base.BOBase
    {
        public DateTime DateArrived { get; private set; }
        public Dictionary<Component, int> Components { get; private set; }

        public ComponentOrderDelivery(Database.ComponentOrderDelivery delivery)
        {
            Id = delivery.Id;
            DateArrived = delivery.DateArrived;
	        Components = delivery.ComponentsOfComponentOrderDeliveries.ToDictionary(x => new Component(x.Component), x => x.Amount);
        }
    }
}
