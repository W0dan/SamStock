using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.Pedal.UpdatePedal
{
	public class UpdatePedalCommandExecutor : IUpdatePedalCommandExecutor
	{
		private IContext _context;

		public UpdatePedalCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdatePedalCommand cmd)
		{
			var pedal = _context.Pedal.Single(p => p.Id == cmd.Id);
			pedal.Name = cmd.Name;
			pedal.Price = cmd.Price;
			pedal.Margin = cmd.Margin;
		}
	}
}
