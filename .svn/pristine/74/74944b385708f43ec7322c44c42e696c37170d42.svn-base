using System.Linq;
using SAMStock.Database;

namespace SAMStock.DAL.Pedal.DeleteComponent
{
	public class DeleteComponentCommandExecutor: CommandExecutor<DeleteComponentCommand>
	{
		public DeleteComponentCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(DeleteComponentCommand cmd)
		{
			Context.PedalComponent.DeleteObject(Context.PedalComponent.Single(x => x.PedalId == cmd.PedalId && x.ComponentId == cmd.ComponentId));
		}
	}
}
