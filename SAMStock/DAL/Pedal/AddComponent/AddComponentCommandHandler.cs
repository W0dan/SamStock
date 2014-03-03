namespace SAMStock.DAL.Pedal.AddComponent
{
	public class AddComponentCommandHandler: CommandHandler<AddComponentCommand>
	{
		public AddComponentCommandHandler(ICommandExecutor<AddComponentCommand> executor): base (executor)
		{
		}
	}
}
