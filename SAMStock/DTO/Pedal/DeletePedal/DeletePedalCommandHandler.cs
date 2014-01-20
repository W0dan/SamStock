namespace SAMStock.DTO.Pedal.DeletePedal
{
	public class DeletePedalCommandHandler: IDeletePedalCommandHandler
	{
		private readonly IDeletePedalCommandExecutor _executor;

		public DeletePedalCommandHandler(IDeletePedalCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeletePedalCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
