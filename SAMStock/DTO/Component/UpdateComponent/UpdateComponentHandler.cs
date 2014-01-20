namespace SAMStock.DTO.Component.UpdateComponent
{
	public class UpdateComponentHandler:IUpdateComponentHandler
	{
		private readonly IUpdateStockCommandExecutor _executor;

		public UpdateComponentHandler(IUpdateStockCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(UpdateComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
