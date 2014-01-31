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
				if (cmd.Cascade)
				{
					var pcs = _context.PedalComponent.Where(x => x.ComponentId == cmd.Id).Select(x => x).ToList();
					foreach (var pc in pcs)
					{
						_context.PedalComponent.DeleteObject(pc);
					}
					_context.Component.DeleteObject(_context.Component.Single(x => x.Id == cmd.Id));
				}
				else
				{
					var pedalIds = _context.PedalComponent.Where(x => x.ComponentId == cmd.Id).Select(x => x.PedalId).ToList();
					throw new ComponentInUseException(_context.Pedal.Where(x => pedalIds.Contains(x.Id)).Select(x => x.Name).ToList());
				}
			}
		}
	}
}
