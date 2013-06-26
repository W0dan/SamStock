using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;

namespace SamStock.Web.Models.Pedal
{
	public class PedalViewModelComponent
	{
		public String Stocknr { get; private set; }
		public String Description { get; private set; }
		public int Quantity { get; private set; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }

		public PedalViewModelComponent(FilterPedalResponseComponent item)
		{
			Stocknr = item.Stocknr;
			Description = item.Description;
			Price = item.Price;
			Quantity = item.Quantity;
			Stock = item.Stock;
		}
	}
}