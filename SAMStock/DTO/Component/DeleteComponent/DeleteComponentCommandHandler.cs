namespace SAMStock.DTO.Component.DeleteComponent
{
	public class DeleteComponentCommandHandler: IDeleteComponentCommandHandler
	{
		private readonly IDeleteComponentCommandExecutor _executor;

		public DeleteComponentCommandHandler(IDeleteComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeleteComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
