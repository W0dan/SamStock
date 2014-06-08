using System;

namespace SAMStock.BO.Base
{
	public class BOUpdatedEvent<TBO> : EventArgs where TBO : IBO
	{
		public TBO BO { get; private set; }

		public BOUpdatedEvent(TBO bo)
		{
			BO = bo;
		}
	}
}
