using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Delete
{
	public class DeletePedalHandler: CommandHandler<DeletePedalCommand>
	{
		public DeletePedalHandler(ICommandExecutor<DeletePedalCommand> executor) : base(executor)
		{
		}
	}
}
