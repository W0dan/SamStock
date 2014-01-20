namespace SAMStock.DTO.Admin.SetAdminData
{
	public class SetAdminDataHandler : ISetAdminDataHandler
	{
		private readonly  ISetAdminDataCommandExecutor _cmdexecutor;

		public SetAdminDataHandler(ISetAdminDataCommandExecutor cmdexecutor)
		{
			_cmdexecutor = cmdexecutor;
		}

		public void Handle(SetAdminDataCommand cmd)
		{
			_cmdexecutor.Execute(cmd);
		}
	}
}
