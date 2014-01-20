using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.DTO.Pedal.UpdatePedal
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
