namespace SAMStock.DTO.Pedal.AddPedal
{
	public class AddPedalCommandHandler : IAddPedalCommandHandler
	{
		private readonly IAddPedalCommandExecutor _cmdexecutor;

		public AddPedalCommandHandler(IAddPedalCommandExecutor cmdexecutor)
		{
			_cmdexecutor = cmdexecutor;
		}

		public void Handle(AddPedalCommand cmd)
		{
			_cmdexecutor.Execute(cmd);
		}
	}
}
