namespace SAMStock.Pedal.UpdatePedal
{
	public class UpdatePedalCommandHandler : IUpdatePedalCommandHandler
	{
		private readonly IUpdatePedalCommandExecutor _commandexecutor;

		public UpdatePedalCommandHandler(IUpdatePedalCommandExecutor commandexecutor)
		{
			_commandexecutor = commandexecutor;
		}

		public void Handle(UpdatePedalCommand cmd)
		{
			_commandexecutor.Execute(cmd);
		}
	}
}
