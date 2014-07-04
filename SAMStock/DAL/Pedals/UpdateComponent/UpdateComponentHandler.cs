using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.UpdateComponent
{
	public class UpdateComponentHandler: CommandHandler<UpdateComponentCommand>
	{
		public UpdateComponentHandler(ICommandExecutor<UpdateComponentCommand> executor) : base(executor)
		{
		}
	}
}
