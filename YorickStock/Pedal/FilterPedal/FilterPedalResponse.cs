using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.FilterPedal
{
	public class FilterPedalResponse
	{
		public List<FilterPedalResponsePedal> Pedals { get; private set; }

		public FilterPedalResponse()
		{
			Pedals = new List<FilterPedalResponsePedal>();
		}
	}
}
