using SAMStock.Database;

namespace SAMStock.DAL.Base
{
	public abstract class CommandExecutor<TCommand>: ICommandExecutor<TCommand>
	{
		protected readonly IContext Context;

		protected CommandExecutor(IContext context)
		{
			Context = context;
		}

		public abstract int Execute(TCommand cmd);
	}
}
