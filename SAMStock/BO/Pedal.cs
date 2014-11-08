using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SAMStock.BO.Foundation;
using SAMStock.DAL.Pedals.FilterComponents;
using Util.Collections;

namespace SAMStock.BO
{
	public class Pedal : BusinessObject
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal ProfitMargin { get; private set; }
		public event EventHandler<Pedal> Deleted;
		public event EventHandler<Pedal> Updated;

		internal Pedal(Database.Pedal pedal, decimal defaultprofitmargin)
		{
			Id = pedal.Id;
			Name = pedal.Name;
			Price = pedal.Price;
			ProfitMargin = pedal.ProfitMargin?? defaultprofitmargin;

			Pedals s = new Singleton<Pedals>();
			s.Deleted += (sender, deleted) =>
			{
				if (deleted.Id.Equals(Id))
				{
					Delete();
				}
			};
			s.Updated += (sender, updated) =>
			{
				if (updated.BO.Id.Equals(Id))
				{
					Update(updated.BO);
				}
			};
		}

		public Dictionary<Component, int> Components
		{
			get
			{
				return Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest(this)
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
			}).Items;
			var max = (int?)null;
			foreach (var component in Components)
			{
				var count = (int) Math.Floor((double) allcomponents.Single(x => x.Id == component.Key.Id).Stock/component.Value);
				max = max.HasValue ? Math.Min(max.Value, count) : count;
			}
			return max ?? 0;
		}

		private void Delete()
		{
			var handler = Deleted;
			if (handler != null)
			{
				handler(null, this);
			}
		}

		private void Update(Pedal p)
		{
			var handler = Updated;
			if (handler != null)
			{
				handler(null, this);
			}
		}
	}
}
