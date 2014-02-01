namespace SAMStock.DTO
{
	public abstract class CommandHandler<TCommand>: ICommandHandler<TCommand>
	{
		protected readonly ICommandExecutor<TCommand> Executor;

		protected CommandHandler(ICommandExecutor<TCommand> executor)
		{
			Executor = executor;
		}

		public void Handle(TCommand cmd)
		{
			Executor.Execute(cmd);
		}
	}
}
