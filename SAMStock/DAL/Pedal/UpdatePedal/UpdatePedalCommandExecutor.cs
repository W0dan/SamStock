using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.DAL.Pedal.UpdatePedal
{
	public class UpdatePedalCommandExecutor : CommandExecutor<UpdatePedalCommand>
	{
		public UpdatePedalCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(UpdatePedalCommand cmd)
		{
			var pedal = Context.Pedal.Single(p => p.Id == cmd.Id);
			if (!cmd.Name.IsNullOrEmpty()) pedal.Name = cmd.Name;
			if (cmd.Price.HasValue) pedal.Price = cmd.Price.Value;
			if (cmd.Margin.HasValue) pedal.Margin = cmd.Margin;
		}
	}
}
