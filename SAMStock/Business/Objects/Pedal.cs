using System;
using System.Collections.Generic;
using System.Linq;
using SAMStock.Business.Events;
using SAMStock.Business.Foundation;
using SAMStock.Business.Managers;
using SAMStock.Castle;
using SAMStock.DAL.Pedals.FilterComponents;

namespace SAMStock.Business.Objects
{
	public class Pedal: IBusinessObject
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal ProfitMargin { get; private set; }
		public event EventHandler Deleted = delegate { };
		public event EventHandler<Pedal> Updated = delegate { };

		internal Pedal(Database.Pedal pedal, decimal defaultprofitmargin)
		{
			Id = pedal.Id;
			Name = pedal.Name;
			Price = pedal.Price;
			ProfitMargin = pedal.ProfitMargin?? defaultprofitmargin;

			var mgr = Pedals.Events;
			mgr.RegisterDelete((x, y) =>
			{
				if (y.BOId.Equals(Id))
				{
					Deleted(x, null);
				}
			});
			mgr.RegisterUpdate((x, y) =>
			{
				if (y.BO.Id.Equals(Id))
				{
					Updated(x, y.BO);
				}
			});
		}

		public Dictionary<Component, int> Components
		{
			get
			{
				return Dispatcher.Request<DAL.Components.Filter.FilterComponentsRequest, DAL.Components.Filter.FilterComponentsResponse>(new FilterComponentsRequest(this)
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
			var allcomponents = Dispatcher.Request<DAL.Components.Filter.FilterComponentsRequest, DAL.Components.Filter.FilterComponentsResponse>(new DAL.Components.Filter.FilterComponentsRequest(this)
			{
				PedalId = Id
			}).Components;
			var max = (int?)null;
			foreach (var component in Components)
			{
				var count = (int) Math.Floor((double) allcomponents.Single(x => x.Id == component.Key.Id).Stock/component.Value);
				max = max.HasValue ? Math.Min(max.Value, count) : count;
			}
			return max ?? 0;
		}
	}
}
