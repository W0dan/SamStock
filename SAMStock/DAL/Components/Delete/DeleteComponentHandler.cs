using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentHandler: CommandHandler<DeleteComponentRequest>
	{
		public DeleteComponentHandler(ICommandExecutor<DeleteComponentRequest> executor) : base(executor)
		{
		}
	}
}
