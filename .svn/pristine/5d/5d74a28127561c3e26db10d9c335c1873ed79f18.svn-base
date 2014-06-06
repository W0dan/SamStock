using System.Linq;
using SAMStock.Database;

namespace SAMStock.DAL.Pedal.DeletePedal
{
	public class DeletePedalCommandExecutor: CommandExecutor<DeletePedalCommand>
	{
		public DeletePedalCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(DeletePedalCommand cmd)
		{
			if (cmd.Cascade)
			{
				var delete = Context.PedalComponent.Where(x => x.PedalId == cmd.Id);
				foreach (var pedalcomp in delete)
				{
					Context.PedalComponent.DeleteObject(pedalcomp);
				}
			}
			Context.Pedal.DeleteObject(Context.Pedal.Single(x => x.Id == cmd.Id));
		}
	}
}
