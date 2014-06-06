using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Config.CreateConfig
{
	public class CreateConfigHandler: CommandHandler<CreateConfigCommand>
	{
		public CreateConfigHandler(ICommandExecutor<CreateConfigCommand> executor) : base(executor)
		{
		}
	}
}
