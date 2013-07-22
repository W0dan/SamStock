using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.FilterPedal
{
	public class FilterPedalResponsePedal
	{
		public List<FilterPedalResponseComponent> Components { get; set; }
		public int Id { get; set; }
		public String Name { get; set; }
		public decimal Price { get; set; }
		public decimal Margin { get; set; }

		public FilterPedalResponsePedal()
		{
			Components = new List<FilterPedalResponseComponent>();
		}
	}
}
