using System.Linq;
using SAMStock.Database;
using SAMStock.DTO.Component.DeleteComponent.Exceptions;

namespace SAMStock.DTO.Component.DeleteComponent
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
			if (_context.PedalComponent.Count(x => x.ComponentId == cmd.Id) == 0)
			{
				_context.Component.DeleteObject(_context.Component.Single(x => x.Id == cmd.Id));
			}
			else
			{
				throw new ComponentInUseException();
			}
		}
	}
}
