using System;
using SAMStock.DAL.Base;

namespace SAMStock.BO.Base
{
	public abstract class BOManager<TBO> where TBO: IBO
	{
		public static event EventHandler<BOCreatedEvent<TBO>> Created;
		public static event EventHandler<BOUpdatedEvent<TBO>> Updated;
		public static event EventHandler<BODeletedEvent<TBO>> Deleted;

		internal static void TriggerCreated(ICreateCommand<TBO> command, TBO bo)
		{
			var handler = Created;
			if (handler != null)
			{
				handler(command, new BOCreatedEvent<TBO>(bo));
			}
		}

		internal static void TriggerDeleted(IDeleteCommand<TBO> command, int id)
		{
			var handler = Deleted;
			if (handler != null)
			{
				handler(command, new BODeletedEvent<TBO>(id));
			}
		}

		internal static void TriggerUpdated(IUpdateCommand<TBO> command, TBO bo)
		{
			var handler = Updated;
			if (handler != null)
			{
				handler(command, new BOUpdatedEvent<TBO>(bo));
			}
		}
	}
}