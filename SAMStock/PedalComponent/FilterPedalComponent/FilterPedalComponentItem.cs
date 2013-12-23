using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.FilterPedalComponent
{
	public class FilterPedalComponentResponseItem
	{
		public FilterPedalComponentResponsePedal Pedal { get; set; }
		public FilterPedalComponentResponseComponent Component { get; set; }
		public int Quantity { get; set; }
	}
}
