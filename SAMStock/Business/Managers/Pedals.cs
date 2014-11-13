using System.Collections.Generic;
using Castle.Core.Internal;
using SAMStock.Business.Events;
using SAMStock.Business.Foundation;
using SAMStock.Business.Objects;
using SAMStock.DAL.Pedals.Filter;

namespace SAMStock.Business.Managers
{
	public class Pedals: Manager<Pedal>
	{
		private static readonly List<long> HandledComponentEvents = new List<long>();
		private static bool _registeredToComponents = false;

		internal Pedals(IManager<Component> cmp)
		{
			if (!_registeredToComponents)
			{
				cmp.RegisterCreate(HandleCreate);
				cmp.RegisterDelete(HandleDelete);
				cmp.RegisterUpdate(HandleUpdate);
				_registeredToComponents = true;
			}
		}

		internal static void HandleCreate(object sender, Created<Component> created)
		{
			lock (HandledComponentEvents)
			{
				if (!HandledComponentEvents.Contains(created.Id))
				{
					HandledComponentEvents.Add(created.Id);
					var pedals = Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest(Events)
					{
						ComponentId = created.BO.Id
					}).Pedals;
					pedals.ForEach(x => Events.TriggerCreate(sender, x));
				}
			}
		}

		internal static void HandleDelete(object sender, Deleted<Component> deleted)
		{
			lock (HandledComponentEvents)
			{
				if (!HandledComponentEvents.Contains(deleted.Id))
				{
					HandledComponentEvents.Add(deleted.Id);
					var pedals = Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest(Events)
					{
						ComponentId = deleted.BOId
					}).Pedals;
					pedals.ForEach(x => Events.TriggerDelete(sender, deleted.BOId));
				}
			}
		}

		internal static void HandleUpdate(object sender, Updated<Component> updated)
		{
			lock (HandledComponentEvents)
			{
				if (!HandledComponentEvents.Contains(updated.Id))
				{
					HandledComponentEvents.Add(updated.Id);
					var pedals = Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest(Events)
					{
						ComponentId = updated.BO.Id
					}).Pedals;
					pedals.ForEach(x => Events.TriggerUpdate(sender, x));
				}
			}
		}
	}
}