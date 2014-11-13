using System;
using SAMStock.Business.Foundation;
using Util;

namespace SAMStock.Business.Events
{
	public abstract class Event<T> : IEvent<T> where T: IBusinessObject
	{
		public long Id { get; private set; }

		protected Event()
		{
			Id = UniqueId.Get<T>();
		}
	}
}