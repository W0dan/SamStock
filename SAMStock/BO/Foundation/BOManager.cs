using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Foundation
{
	public abstract class BOManager<T>: IBOManager<T> where T: IBusinessObject
	{
		private readonly static List<WeakReference<ICreateListener<T>>> CreateListeners = new List<WeakReference<ICreateListener<T>>>();
		private readonly static List<WeakReference<IDeleteListener<T>>> DeleteListeners = new List<WeakReference<IDeleteListener<T>>>();
		private readonly static List<WeakReference<IUpdateListener<T>>> UpdateListeners = new List<WeakReference<IUpdateListener<T>>>();

		public void RegisterCreate(ICreateListener<T> listener)
		{
			CreateListeners.Add(new WeakReference<ICreateListener<T>>(listener));
		}

		public void RegisterDelete(IDeleteListener<T> listener)
		{
			DeleteListeners.Add(new WeakReference<IDeleteListener<T>>(listener));
		}

		public void RegisterUpdate(IUpdateListener<T> listener)
		{
			UpdateListeners.Add(new WeakReference<IUpdateListener<T>>(listener));
		}

		internal void Create(Object sender, T bo)
		{
			lock (CreateListeners)
			{
				var e = new Created<T>(bo);
				for (var i = 0; i < CreateListeners.Count;i++)
				{
					ICreateListener<T> listener;
					CreateListeners[i].TryGetTarget(out listener);
					if (listener != null)
					{
						listener.HandleCreate(sender, e);
					}
					else
					{
						CreateListeners.Remove(CreateListeners[i--]);
					}
				}
			}
		}

		internal void Delete(Object sender, int id)
		{
			lock (DeleteListeners)
			{
				var e = new Deleted<T>(id);
				for (var i = 0; i < DeleteListeners.Count; i++)
				{
					IDeleteListener<T> listener;
					DeleteListeners[i].TryGetTarget(out listener);
					if (listener != null)
					{
						listener.HandleDelete(sender, e);
					}
					else
					{
						DeleteListeners.Remove(DeleteListeners[i--]);
					}
				}
			}
		}

		internal void Update(Object sender, T bo)
		{
			lock (UpdateListeners)
			{
				var e = new Updated<T>(bo);
				for (var i = 0; i < UpdateListeners.Count; i++)
				{
					IUpdateListener<T> listener;
					UpdateListeners[i].TryGetTarget(out listener);
					if (listener != null)
					{
						listener.HandleUpdate(sender, e);
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
