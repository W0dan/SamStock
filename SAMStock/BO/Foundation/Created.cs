using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.BO.Foundation
{
	public class Created<TBO>: BOEvent where TBO: IBusinessObject
	{
		public TBO BO { get; private set; }

		internal Created(TBO bo)
		{
			BO = bo;
		}
	}
}
