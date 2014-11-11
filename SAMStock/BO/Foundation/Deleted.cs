using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Foundation
{
	public class Deleted<TBO>: BOEvent where TBO: IBusinessObject
	{
		public int Id { get; private set; }

		internal Deleted(int id)
		{
			Id = id;
		}
	}
}
