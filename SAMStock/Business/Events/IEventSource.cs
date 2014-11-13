using System;
using SAMStock.Business.Foundation;

namespace SAMStock.Business.Events
{
	public interface IEventSource<T> where T: IBusinessObject
	{
		void RegisterCreate(Action<Object, Created<T>> listener);
		void RegisterDelete(Action<Object, Deleted<T>> listener);
		void RegisterUpdate(Action<Object, Updated<T>> listener);
	}
}