using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Pedal.DeletePedal
{
	public class DeletePedalCommandExecutor: IDeletePedalCommandExecutor
	{
		private readonly IContext _context;

		public DeletePedalCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(DeletePedalCommand cmd)
		{
			if (cmd.Cascade)
			{
				var delete = _context.PedalComponent.Where(x => x.PedalId == cmd.Id);
				foreach (var pedalcomp in delete)
				{
					_context.PedalComponent.DeleteObject(pedalcomp);
				}
			}
			_context.Pedal.DeleteObject(_context.Pedal.Single(x => x.Id == cmd.Id));
		}
	}
}
