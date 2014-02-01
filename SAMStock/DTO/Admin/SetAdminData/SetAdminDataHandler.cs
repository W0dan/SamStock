namespace SAMStock.DTO.Admin.SetAdminData
{
	public class SetAdminDataHandler : CommandHandler<SetAdminDataCommand>
	{
		public SetAdminDataHandler(ICommandExecutor<SetAdminDataCommand> cmdexecutor): base(cmdexecutor)
		{
		}
	}
}
