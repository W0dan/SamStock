namespace SAMStock.DTO.Pedal.AddComponent
{
	public class AddComponentCommandHandler: CommandHandler<AddComponentCommand>
	{
		public AddComponentCommandHandler(ICommandExecutor<AddComponentCommand> executor): base (executor)
		{
		}
	}
}
