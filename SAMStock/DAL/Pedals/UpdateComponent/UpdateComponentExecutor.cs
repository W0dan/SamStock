using System.Linq;
using SAMStock.DAL.Base;
using SAMStock.Database;
using Pedal = SAMStock.BO.Pedal;

namespace SAMStock.DAL.Pedals.UpdateComponent
{
	public class UpdateComponentExecutor: CommandExecutor<UpdateComponentCommand>
	{
		public UpdateComponentExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(UpdateComponentCommand cmd)
		{
			var cop = Context.ComponentsOfPedals.Single(x => x.ComponentId == cmd.ComponentId && x.PedalId == cmd.PedalId);
			cop.Amount = cmd.Amount;
			Context.SaveChanges();
			var pedal = Context.Pedals.Single(x => x.Id == cmd.PedalId);
			return cop.Id;
		}
	}
}
