using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Pedal.AddPedal
{
	public class AddPedalCommandExecutor : IAddPedalCommandExecutor
	{
		private readonly IContext _context;

		public AddPedalCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(AddPedalCommand cmd)
		{
			_context.Pedal.AddObject(new Database.Pedal
			{
				Name = cmd.Name,
				Price = cmd.Price,
				Margin = cmd.Margin
			});
		}
	}
}
