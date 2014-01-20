using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Pedal.UpdateComponent
{
	public class UpdateComponentCommandExecutor:IUpdateComponentCommandExecutor
	{
		private readonly IContext _context;

		public UpdateComponentCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdateComponentCommand cmd)
		{
			_context.PedalComponent.Single(x => x.PedalId == cmd.PedalId && x.ComponentId == cmd.ComponentId).Number = cmd.Quantity;
		}
	}
}
