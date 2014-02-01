using System.Linq;
using SAMStock.Database;
using SAMStock.DTO.Component.DeleteComponent.Exceptions;

namespace SAMStock.DTO.Component.DeleteComponent
{
	public class DeleteComponentCommandExecutor: CommandExecutor<DeleteComponentCommand>
	{
		public DeleteComponentCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(DeleteComponentCommand cmd)
		{
			if (Context.PedalComponent.Count(x => x.ComponentId == cmd.Id) == 0)
			{
				Context.Component.DeleteObject(Context.Component.Single(x => x.Id == cmd.Id));
			}
			else
			{
				if (cmd.Cascade)
				{
					var pcs = Context.PedalComponent.Where(x => x.ComponentId == cmd.Id).Select(x => x).ToList();
					foreach (var pc in pcs)
					{
						Context.PedalComponent.DeleteObject(pc);
					}
					Context.Component.DeleteObject(Context.Component.Single(x => x.Id == cmd.Id));
				}
				else
				{
					var pedalIds = Context.PedalComponent.Where(x => x.ComponentId == cmd.Id).Select(x => x.PedalId).ToList();
					throw new ComponentInUseException(Context.Pedal.Where(x => pedalIds.Contains(x.Id)).Select(x => x.Name).ToList());
				}
			}
		}
	}
}
