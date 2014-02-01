using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Pedal.UpdateComponent
{
	public class UpdateComponentCommandExecutor: CommandExecutor<UpdateComponentCommand>
	{
		public UpdateComponentCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(UpdateComponentCommand cmd)
		{
			Context.PedalComponent.Single(x => x.PedalId == cmd.PedalId && x.ComponentId == cmd.ComponentId).Number = cmd.Quantity;
		}
	}
}
