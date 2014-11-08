using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.RemoveComponent
{
	public class RemoveComponentHandler: CommandHandler<RemoveComponentCommand>
	{
		public RemoveComponentHandler(ICommandExecutor<RemoveComponentCommand> executor) : base(executor)
		{
		}
	}
}
