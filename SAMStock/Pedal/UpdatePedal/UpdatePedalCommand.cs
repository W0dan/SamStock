using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Pedal.UpdatePedal
{
	public class UpdatePedalCommand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public decimal? Margin { get; set; }
	}
}
