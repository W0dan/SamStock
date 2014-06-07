using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.AddComponent
{
	public class AddComponentHandler: CommandHandler<AddComponentCommand>
	{
		public AddComponentHandler(ICommandExecutor<AddComponentCommand> executor) : base(executor)
		{
		}
	}
}
