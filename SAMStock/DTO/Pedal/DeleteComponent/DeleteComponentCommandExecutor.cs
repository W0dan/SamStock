using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Pedal.DeleteComponent
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
			_context.PedalComponent.DeleteObject(_context.PedalComponent.Single(x => x.PedalId == cmd.PedalId && x.ComponentId == cmd.ComponentId));
		}
	}
}
