using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMStock.Pedal.FilterPedal;

namespace SAMStock.Web.Models.Pedal
{
	public class PedalViewModelPedal
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public decimal Price { get; set; }
		public decimal Margin { get; set; }
		public List<PedalViewModelComponent> Components = new List<PedalViewModelComponent>();

		public PedalViewModelPedal(FilterPedalResponsePedal item)
		{
			Name = item.Name;
			Id = item.Id;
			Price = item.Price;
			Margin = item.Margin;

			foreach (FilterPedalResponseComponent comp in item.Components)
			{
				Components.Add(new PedalViewModelComponent(comp));
			}
		}

		public PedalViewModelPedal(int id, string name, decimal price, decimal margin)
		{
			Id = id;
			Name = name;
			Price = price;
			Margin = margin;
		}

		public PedalViewModelPedal()
		{
		}
	}
}