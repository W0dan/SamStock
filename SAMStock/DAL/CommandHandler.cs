namespace SAMStock.DAL
{
	public abstract class CommandHandler<TCommand>: ICommandHandler<TCommand>
	{
		protected readonly ICommandExecutor<TCommand> Executor;

		protected CommandHandler(ICommandExecutor<TCommand> executor)
		{
			Executor = executor;
		}

		public int Handle(TCommand cmd)
		{
			return Executor.Execute(cmd);
		}
	}
}
