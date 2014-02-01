namespace SAMStock.DTO.Component.UpdateComponent
{
	public class UpdateComponentHandler: CommandHandler<UpdateComponentCommand>
	{
		public UpdateComponentHandler(ICommandExecutor<UpdateComponentCommand> executor): base(executor)
		{
		}
	}
}
