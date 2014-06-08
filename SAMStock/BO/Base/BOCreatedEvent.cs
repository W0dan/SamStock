using System;

namespace SAMStock.BO.Base
{
	public class BOCreatedEvent<TBO>: EventArgs where TBO: IBO
	{
		public TBO BO { get; private set; }

		public BOCreatedEvent(TBO bo)
		{
			BO = bo;
		}
	}
}
