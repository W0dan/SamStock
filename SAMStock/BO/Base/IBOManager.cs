using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Base
{
	public interface IBOManager<T> where T: BOBase
	{
		event EventHandler<T> Created;
		event EventHandler<BODeletedEvent> Deleted;
		event EventHandler<T> Updated;
	}

	public class BODeletedEvent : EventArgs
	{
		public int Id { get; private set; }

		internal BODeletedEvent(int id)
		{
			Id = id;
		}
	}
}
