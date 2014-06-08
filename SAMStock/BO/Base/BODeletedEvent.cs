using System;

namespace SAMStock.BO.Base
{
	public class BODeletedEvent<TBO> : EventArgs where TBO : IBO
	{
		public int Id { get; private set; }

		public BODeletedEvent(int id)
		{
			Id = id;
		}
	}
}
