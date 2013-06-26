using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Pedal.UpdatePedalComponents
{
	public class UpdatePedalComponentsCommandExecutor : IUpdatePedalComponentsCommandExecutor
	{
		private IContext _context;

		public UpdatePedalComponentsCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdatePedalComponentsCommand cmd)
		{
			if (_context.PedalComponent.Where(p => p.PedalId == cmd.Id && p.ComponentId == cmd.ComponentId).Count() == 1)
			{
				var pedalcomp = _context.PedalComponent.Where(p => p.PedalId == cmd.Id && p.ComponentId == cmd.ComponentId).Single();
				if (pedalcomp.Number + cmd.Quantity > 0)
				{
					pedalcomp.Number = pedalcomp.Number + cmd.Quantity;
				}
				else
				{
					_context.PedalComponent.DeleteObject(pedalcomp);
				}
			}
			else
			{
				if (cmd.Quantity > 0)
				{
					_context.PedalComponent.AddObject(new PedalComponent
					{
						PedalId = cmd.Id,
						ComponentId = cmd.ComponentId,
						Number = cmd.Quantity
					});
				}
			}
		}
	}
}
