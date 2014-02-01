namespace SAMStock.DTO.Pedal.DeleteComponent
{
	public class DeleteComponentCommandHandler: CommandHandler<DeleteComponentCommand>
	{
		public DeleteComponentCommandHandler(ICommandExecutor<DeleteComponentCommand> executor): base(executor)
		{
		}
	}
}
