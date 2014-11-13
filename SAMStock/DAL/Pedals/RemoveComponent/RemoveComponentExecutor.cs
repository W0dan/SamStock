using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using Pedal = SAMStock.Business.Objects.Pedal;

namespace SAMStock.DAL.Pedals.RemoveComponent
{
	public class RemoveComponentExecutor: CommandExecutor<RemoveComponentCommand>
	{
		public RemoveComponentExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(RemoveComponentCommand cmd)
		{
			var cop = Context.ComponentsOfPedals.Single(x => x.ComponentId == cmd.ComponentId && x.PedalId == cmd.PedalId);
			Context.ComponentsOfPedals.Remove(cop);
			Context.SaveChanges();
			var pedal = Context.Pedals.Single(x => x.Id == cmd.PedalId);
			Business.Managers.Pedals.Manager.TriggerUpdated(new Pedal(pedal, Context.Config.Single().DefaultPedalProfitMargin));
			return cop.Id;
		}
	}
}
