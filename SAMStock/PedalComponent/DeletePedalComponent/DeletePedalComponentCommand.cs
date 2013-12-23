using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.DeletePedalComponent
{
	public class DeletePedalComponentCommand
	{
		public int PedalId { get; set; }
		public int ComponentId { get; set; }
	}
}
