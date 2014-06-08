using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.RemoveComponent
{
	public class RemoveComponentHandler: CommandHandler<RemoveComponentCommand>
	{
		public RemoveComponentHandler(ICommandExecutor<RemoveComponentCommand> executor) : base(executor)
		{
		}
	}
}
