using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Delete
{
	public class DeletePedalHandler: CommandHandler<DeletePedalCommand>
	{
		public DeletePedalHandler(ICommandExecutor<DeletePedalCommand> executor) : base(executor)
		{
		}
	}
}
