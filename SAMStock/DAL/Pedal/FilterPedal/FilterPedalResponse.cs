﻿using System.Collections.Generic;

namespace SAMStock.DAL.Pedal.FilterPedal
{
	public class FilterPedalResponse
	{
		public List<FilterPedalResponsePedal> Pedals { get; set; }

		public FilterPedalResponse()
		{
			Pedals = new List<FilterPedalResponsePedal>();
		}
	}
}