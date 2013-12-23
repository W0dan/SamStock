using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.PedalComponent.AddPedalComponent
{
	public class AddPedalComponentCommandExecutor: IAddPedalComponentCommandExecutor
	{
		private readonly IContext _context;

		public AddPedalComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(AddPedalComponentCommand cmd)
		{
			_context.PedalComponent.AddObject(new Database.PedalComponent
			{
				ComponentId = cmd.ComponentId,
				PedalId = cmd.PedalId,
				Number = cmd.Quantity
			});
		}
	}
}
