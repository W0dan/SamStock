using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentHandler: CommandHandler<CreateComponentCommand>
	{
		public CreateComponentHandler(ICommandExecutor<CreateComponentCommand> executor) : base(executor)
		{
		}
	}
}
