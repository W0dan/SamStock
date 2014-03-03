namespace SAMStock.DAL.Pedal.UpdatePedal
{
	public class UpdatePedalCommandHandler : CommandHandler<UpdatePedalCommand>
	{
		public UpdatePedalCommandHandler(ICommandExecutor<UpdatePedalCommand> commandexecutor): base(commandexecutor)
		{
		}
	}
}
