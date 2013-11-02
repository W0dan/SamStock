using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Pedal.FilterPedal
{
	public class FilterPedalRequest
	{
		public int Id { get; private set; }

		public FilterPedalRequest()
		{
			Id = 0;
		}

		public FilterPedalRequest(int id)
		{
			Id = id;
		}
	}
}
