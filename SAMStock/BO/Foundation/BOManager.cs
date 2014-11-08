using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Foundation
{
	public abstract class BOManager<T>: IBOManager<T> where T: IBusinessObject
	{
		public event EventHandler<Created<T>> Created;
		public event EventHandler<Deleted<T>> Deleted;
		public event EventHandler<Updated<T>> Updated;

		internal void Create(T bo)
		{
			var handler = Created;
			if (handler != null)
			{
				handler(null, new Created<T>(bo));
			}
		}

		internal void Delete(int id)
		{
			var handler = Deleted;
			if (handler != null)
			{
				handler(null, new Deleted<T>(id));
			}
		}

		internal void Update(T bo)
		{
			var handler = Updated;
			if (handler != null)
			{
				handler(null, new Updated<T>(bo));
			}
		}
	}
}
