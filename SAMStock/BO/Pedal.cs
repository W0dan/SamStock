using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SAMStock.BO.Base;
using SAMStock.DAL.Pedals.FilterComponents;

namespace SAMStock.BO
{
	public class Pedal: IBO
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal ProfitMargin { get; private set; }

		public Pedal(Database.Pedal pedal, decimal defaultprofitmargin)
		{
			Id = pedal.Id;
			Name = pedal.Name;
			Price = pedal.Price;
			ProfitMargin = pedal.ProfitMargin?? defaultprofitmargin;
		}

		public Dictionary<Component, int> Components
		{
			get
			{
				return Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest
				{
					PedalId = Id
				}).Components;
			}
		}

		public int VirtualStock
		{
			get { return CalculateVirtualStock(); }
		}

		private int CalculateVirtualStock()
		{
			var allcomponents = Dispatcher.Request<DAL.Components.Filter.FilterComponentsRequest, DAL.Components.Filter.FilterComponentsResponse>(new DAL.Components.Filter.FilterComponentsRequest()).Items;
			var max = (int?)null;
			foreach (var component in Components)
			{
				if (max.HasValue)
				{
					max = Math.Min(max.Value, (int)Math.Floor((double) allcomponents.Single(x => x.Id == component.Key.Id).Stock / component.Value));
				}
				else
				{
					max = (int)Math.Floor((double) allcomponents.Single(x => x.Id == component.Key.Id).Stock / component.Value);
				}
			}
			return max ?? 0;
		}
	}
}
