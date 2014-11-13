using System;
using System.Collections.Generic;
using SAMStock.Business.Events;
using SAMStock.Business.Objects;

namespace SAMStock.Business.Foundation
{
	public abstract class Manager<T>: IManager<T> where T: IBusinessObject
	{
		private static readonly EventSource<T> _events = new EventSource<T>(); 
		internal static EventSource<T> Events {
			get
			{
				return _events;
			}
		}

		public virtual void RegisterCreate(Action<object, Created<T>> listener)
		{
			Events.RegisterCreate(listener);
		}

		public virtual void RegisterDelete(Action<object, Deleted<T>> listener)
		{
			Events.RegisterDelete(listener);
		}

		public virtual void RegisterUpdate(Action<object, Updated<T>> listener)
		{
			Events.RegisterUpdate(listener);
		}
	}
}
