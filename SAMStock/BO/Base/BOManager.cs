using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Base
{
	public class BOManager<T>: IBOManager<T> where T: BOBase
	{
		public event EventHandler<T> Created;
		public event EventHandler<BODeletedEvent> Deleted;
		public event EventHandler<T> Updated;

		internal void TriggerCreated(T bo)
		{
			var handler = Created;
			if (handler != null)
			{
				handler(null, bo);
			}
		}

		internal void TriggerDeleted(int id)
		{
			var handler = Deleted;
			if (handler != null)
			{
				handler(null, new BODeletedEvent(id));
			}
		}

		internal void TriggerUpdated(T bo)
		{
			var handler = Updated;
			if (handler != null)
			{
				handler(null, bo);
			}
		}
	}
}
