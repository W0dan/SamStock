using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.UpdatePedalComponent
{
	public class UpdatePedalComponentCommand
	{
		public int PedalId { get; set; }
		public int ComponentId { get; set; }
		public int Quantity { get; set; }
	}
}
