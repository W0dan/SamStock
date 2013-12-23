using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Component.DeleteComponent
{
	public class DeleteComponentCommandExecutor: IDeleteComponentCommandExecutor
	{
		private readonly IContext _context;

		public DeleteComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(DeleteComponentCommand cmd)
		{
			_context.Component.DeleteObject(_context.Component.Single(x => x.Id == cmd.Id));
		}
	}
}
