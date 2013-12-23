using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.AddPedalComponent
{
	public class AddPedalComponentCommand
	{
		public int ComponentId { get; set; }
		public int PedalId { get; set; }
		public int Quantity { get; set; }
	}
}
