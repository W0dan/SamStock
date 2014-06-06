using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO
{
	public class Component
	{
		public int Id { get; private set; }

		public Component(Database.Component component)
		{
			Id = component.Id;
		}
	}
}
