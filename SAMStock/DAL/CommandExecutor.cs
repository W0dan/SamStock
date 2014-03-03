using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.DAL
{
	public abstract class CommandExecutor<TCommand>: ICommandExecutor<TCommand>
	{
		protected readonly IContext Context;

		protected CommandExecutor(IContext context)
		{
			Context = context;
		}

		public abstract void Execute(TCommand cmd);
	}
}
