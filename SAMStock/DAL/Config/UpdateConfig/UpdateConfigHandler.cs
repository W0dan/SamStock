using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigHandler: CommandHandler<UpdateConfigCommand>
	{
		public UpdateConfigHandler(ICommandExecutor<UpdateConfigCommand> executor) : base(executor)
		{
		}
	}
}
