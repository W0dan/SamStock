namespace SAMStock.DTO.Pedal.UpdateComponent
{
	public class UpdateComponentCommandHandler: CommandHandler<UpdateComponentCommand>
	{
		public UpdateComponentCommandHandler(ICommandExecutor<UpdateComponentCommand> executor): base(executor)
		{
		}
	}
}
