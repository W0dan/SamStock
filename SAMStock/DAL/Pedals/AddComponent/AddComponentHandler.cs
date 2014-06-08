using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.AddComponent
{
	public class AddComponentHandler: CommandHandler<AddComponentCommand>
	{
		public AddComponentHandler(ICommandExecutor<AddComponentCommand> executor) : base(executor)
		{
		}
	}
}
