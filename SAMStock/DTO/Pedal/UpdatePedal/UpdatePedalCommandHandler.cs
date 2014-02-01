namespace SAMStock.DTO.Pedal.UpdatePedal
{
	public class UpdatePedalCommandHandler : CommandHandler<UpdatePedalCommand>
	{
		public UpdatePedalCommandHandler(ICommandExecutor<UpdatePedalCommand> commandexecutor): base(commandexecutor)
		{
		}
	}
}
