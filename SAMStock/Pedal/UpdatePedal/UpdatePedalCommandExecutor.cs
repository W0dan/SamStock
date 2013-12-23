using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.Pedal.UpdatePedal
{
	public class UpdatePedalCommandExecutor : IUpdatePedalCommandExecutor
	{
		private readonly IContext _context;

		public UpdatePedalCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdatePedalCommand cmd)
		{
			var pedal = _context.Pedal.Single(p => p.Id == cmd.Id);
			if (!cmd.Name.IsNullOrEmpty()) pedal.Name = cmd.Name;
			if (cmd.Price.HasValue) pedal.Price = cmd.Price.Value;
			if (cmd.Margin.HasValue) pedal.Margin = cmd.Margin;
		}
	}
}
