namespace SAMStock.DAL.Pedal.UpdateComponent
{
	public class UpdateComponentCommandHandler: CommandHandler<UpdateComponentCommand>
	{
		public UpdateComponentCommandHandler(ICommandExecutor<UpdateComponentCommand> executor): base(executor)
		{
		}
	}
}
