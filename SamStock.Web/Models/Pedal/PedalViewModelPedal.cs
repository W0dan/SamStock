using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;

namespace SamStock.Web.Models.Pedal
{
	public class PedalViewModelPedal
	{
		public string Name { get; private set; }
		public int Id { get; private set; }
		public decimal Price { get; private set; }
		public decimal Margin { get; private set; }
		public List<PedalViewModelComponent> List;

		public PedalViewModelPedal(FilterPedalResponsePedal item)
		{
			Name = item.Name;
			Id = item.Id;
			Price = item.Price;
			Margin = item.Margin;
			List = new List<PedalViewModelComponent>();

			foreach (FilterPedalResponseComponent comp in item.List)
			{
				List.Add(new PedalViewModelComponent(comp));
			}
		}

		public PedalViewModelPedal(int id, string name, decimal price, decimal margin)
		{
			Id = id;
			Name = name;
			Price = price;
			Margin = margin;
		}
	}
}