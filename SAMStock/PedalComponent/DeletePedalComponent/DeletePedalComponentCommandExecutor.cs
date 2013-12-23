using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.PedalComponent.DeletePedalComponent
{
	public class DeletePedalComponentCommandExecutor: IDeletePedalComponentCommandExecutor
	{
		private readonly IContext _context;

		public DeletePedalComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(DeletePedalComponentCommand cmd)
		{
			_context.PedalComponent.DeleteObject(_context.PedalComponent.Single(x => x.PedalId == cmd.PedalId && x.ComponentId == cmd.ComponentId));
		}
	}
}
