namespace SAMStock.DTO.Pedal.DeletePedal
{
	public class DeletePedalCommandHandler: CommandHandler<DeletePedalCommand>
	{
		public DeletePedalCommandHandler(ICommandExecutor<DeletePedalCommand> executor): base(executor)
		{
		}
	}
}
