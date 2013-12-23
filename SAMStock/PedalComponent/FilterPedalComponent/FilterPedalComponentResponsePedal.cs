using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.FilterPedalComponent
{
	public class FilterPedalComponentResponsePedal
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public decimal Price { get; set; }
		public decimal DefaultMargin { get; set; }
		public decimal Margin { get; set; }
	}
}
