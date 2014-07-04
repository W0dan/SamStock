﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;

namespace SAMStock.BO
{
    public class ComponentOrderDelivery: IBO
    {
        public int Id { get; private set; }
        public DateTime DateArrived { get; private set; }
        public List<ComponentOrderDeliveryComponent> Components { get; private set; }

        public ComponentOrderDelivery(Database.ComponentOrderDelivery delivery)
        {
            Id = delivery.Id;
            DateArrived = delivery.DateArrived;
            Components = delivery.ComponentsOfComponentOrderDeliveries.Select(x => new ComponentOrderDeliveryComponent(x)).ToList();
        }
    }
}
