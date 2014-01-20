namespace SAMStock.DTO.Pedal.AddComponent
{
	public class AddComponentCommandHandler: IAddComponentCommandHandler
	{
		private readonly IAddComponentCommandExecutor _executor;

		public AddComponentCommandHandler(IAddComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(AddComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
