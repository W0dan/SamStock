using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMStock.Pedal.FilterPedal;
using SAMStock.Stock.FilterStock;

namespace SAMStock.Web.Models.Pedal
{
	public class PedalUpdateComponentsViewModel
	{
		public int Id { get; private set; }
		public List<PedalViewModelComponent> Components { get; private set; }

		public PedalUpdateComponentsViewModel(FilterPedalResponse response)
		{
			Id = response.Pedals[0].Id;
			Components = new List<PedalViewModelComponent>();
			foreach (var item in response.Pedals[0].Components)
			{
				Components.Add(new PedalViewModelComponent(item));
			}
		}
	}
}