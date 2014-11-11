using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Foundation;

namespace SAMStock.BO
{
	public class Pedals: BOManager<Pedal>
	{
		private static List<int> HandledEventIds = new List<int>(); 
		internal Pedals()
		{
			// register listener on components
			// check id for redundancy
			// fetch affected pedals
			// re-publish event
		}
	}
}
