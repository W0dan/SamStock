using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;
using SamStock.Stock.FilterStock;

namespace SamStock.Web.Models.Pedal
{
	public class PedalUpdateComponentsViewModel
	{
		public int Id { get; private set; }
		public List<FilterPedalResponseComponent> List { get; private set; }

		public PedalUpdateComponentsViewModel(FilterPedalResponse response)
		{
			Id = response.List[0].Id;
			List = response.List[0].List;
		}
	}
}