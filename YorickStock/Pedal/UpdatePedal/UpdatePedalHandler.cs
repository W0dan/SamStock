namespace SamStock.Pedal.UpdatePedal
{
	public class UpdatePedalHandler : IUpdatePedalHandler
	{
		private IUpdatePedalCommandExecutor _commandexecutor;

		public UpdatePedalHandler(IUpdatePedalCommandExecutor commandexecutor)
		{
			_commandexecutor = commandexecutor;
		}

		public void Handle(UpdatePedalCommand cmd)
		{
			_commandexecutor.Execute(cmd);
		}
	}
}
