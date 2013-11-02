using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMStock.Pedal.FilterPedal;
using SAMStock.Admin.GetAdminData;

namespace SAMStock.Web.Models.Pedal
{
	public class PedalViewModel
	{
		public List<PedalViewModelPedal> Pedals { get; private set; }
		public decimal VATAmount { get; private set; }
		public int BuildCount { get; private set;}
		public decimal Price { get; private set; }
		public decimal Margin { get; private set; }
		public decimal Baseprice { get; private set; }
		public decimal Profit { get; private set; }
		public decimal Costs { get; private set;}

		public PedalViewModel(FilterPedalResponse response, GetAdminDataResponse admindata)
		{
			Pedals = new List<PedalViewModelPedal>();
			foreach (FilterPedalResponsePedal p in response.Pedals)
			{
				Pedals.Add(new PedalViewModelPedal(p));
			}
			
			BuildCount = 0;
			Costs = 0.0M;
			Price = Pedals[0].Price;
			Margin = Pedals[0].Margin;
			Baseprice = Costs * (Margin + 100) / 100;
			VATAmount = (Price - Costs) * admindata.VAT / 100;
			Profit = Price - Costs - VATAmount;

			if (Pedals[0].Components.Count > 0)
			{
				BuildCount = (int)Math.Floor((double)Pedals[0].Components[0].Stock / Pedals[0].Components[0].Quantity);
				Costs = Pedals[0].Components[0].Price * Pedals[0].Components[0].Quantity;
				
				for (int i = 1; i < Pedals[0].Components.Count; i++)
				{
					var item = Pedals[0].Components[i];
					BuildCount = Math.Min(BuildCount, (int)Math.Floor((double)item.Stock / item.Quantity));
					Costs += item.Price * item.Quantity;
				}
			}
		}
	}
}