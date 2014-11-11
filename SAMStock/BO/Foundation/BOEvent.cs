using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMStock.BO.Foundation
{
	public abstract class BOEvent : IBOEvent
	{
		public int Id { get; private set; }

		protected BOEvent()
		{
			Id = Counter;
		}

		private static int Counter
		{
			get
			{
				int c;
				lock (Lock)
				{
					c = _counter;
					_counter++;
				}
				return c;
			}
		}

		private static int _counter = int.MinValue;
		private static readonly Object Lock = new Object();
	}
}