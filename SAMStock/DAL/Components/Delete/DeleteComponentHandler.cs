using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentHandler: CommandHandler<DeleteComponentCommand>
	{
		public DeleteComponentHandler(ICommandExecutor<DeleteComponentCommand> executor) : base(executor)
		{
		}
	}
}
