namespace SAMStock.DTO.Pedal.UpdateComponent
{
	public class UpdateComponentCommandHandler: IUpdateComponentCommandHandler
	{
		private readonly IUpdateComponentCommandExecutor _executor;

		public UpdateComponentCommandHandler(IUpdateComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(UpdateComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
