namespace SAMStock.DTO.Component.AddComponent
{
	public class AddComponentHandler : CommandHandler<AddComponentCommand>
	{
		public AddComponentHandler(ICommandExecutor<AddComponentCommand> addComponentCommandExecutor): base(addComponentCommandExecutor)
		{
		}
	}
}