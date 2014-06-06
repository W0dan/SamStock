using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentExecutor: CommandExecutor<CreateComponentCommand>
	{
		public CreateComponentExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(CreateComponentCommand cmd)
		{
			return 0;
		}
	}
}