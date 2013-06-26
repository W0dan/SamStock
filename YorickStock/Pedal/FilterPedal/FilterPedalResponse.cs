using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.FilterPedal
{
	public class FilterPedalResponse
	{
		public List<FilterPedalResponsePedal> List { get; private set; }

		public FilterPedalResponse()
		{
			List = new List<FilterPedalResponsePedal>();
		}
	}
}
