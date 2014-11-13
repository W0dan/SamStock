using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMStock.Business.Foundation;

namespace SAMStock.Business.Events
{
	class EventSource<T>: IEventSource<T> where T: IBusinessObject
	{
		private readonly static List<WeakReference<Action<Object, Created<T>>>> CreateListeners = new List<WeakReference<Action<Object, Created<T>>>>();
		private readonly static List<WeakReference<Action<Object, Deleted<T>>>> DeleteListeners = new List<WeakReference<Action<Object, Deleted<T>>>>();
		private readonly static List<WeakReference<Action<Object, Updated<T>>>> UpdateListeners = new List<WeakReference<Action<Object, Updated<T>>>>();

		public void RegisterCreate(Action<Object, Created<T>> listener)
		{
			CreateListeners.Add(new WeakReference<Action<Object, Created<T>>>(listener));
		}

		public void RegisterDelete(Action<Object, Deleted<T>> listener)
		{
			DeleteListeners.Add(new WeakReference<Action<Object, Deleted<T>>>(listener));
		}

		public void RegisterUpdate(Action<Object, Updated<T>> listener)
		{
			UpdateListeners.Add(new WeakReference<Action<Object, Updated<T>>>(listener));
		}

		internal void TriggerCreate(Object sender, T bo)
		{
			lock (CreateListeners)
			{
				var e = new Created<T>(bo);
				for (var i = 0; i < CreateListeners.Count; i++)
				{
					Action<Object, Created<T>> listener;
					if (CreateListeners[i].TryGetTarget(out listener))
					{
						listener(sender, e);
					}
					else
					{
						CreateListeners.Remove(CreateListeners[i--]);
					}
				}
			}
		}

		internal void TriggerDelete(Object sender, int id)
		{
			lock (DeleteListeners)
			{
				var e = new Deleted<T>(id);
				for (var i = 0; i < DeleteListeners.Count; i++)
				{
					Action<Object, Deleted<T>> listener;
					if (DeleteListeners[i].TryGetTarget(out listener))
					{
						listener(sender, e);
					}
					else
					{
						DeleteListeners.Remove(DeleteListeners[i--]);
					}
				}
			}
		}

		internal void TriggerUpdate(Object sender, T bo)
		{
			lock (UpdateListeners)
			{
				var e = new Updated<T>(bo);
				for (var i = 0; i < UpdateListeners.Count; i++)
				{
					Action<Object, Updated<T>> listener;
					if (UpdateListeners[i].TryGetTarget(out listener))
					{
						listener(sender, e);
					}
					else
					{
						UpdateListeners.Remove(UpdateListeners[i--]);
					}
				}
			}
		}
	}
}
