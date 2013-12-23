using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.PedalComponent.UpdatePedalComponent
{
	public class UpdatePedalComponentCommandExecutor
	{
		private readonly IContext _context;

		public UpdatePedalComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdatePedalComponentCommand cmd)
		{
			_context.PedalComponent.Single(x => x.PedalId == cmd.PedalId && x.ComponentId == cmd.ComponentId).Number =
				cmd.Quantity;
		}
	}
}
