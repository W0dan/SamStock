using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Pedals.AddComponent
{
	public class AddComponentExecutor: CommandExecutor<AddComponentCommand>
	{
		public AddComponentExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(AddComponentCommand cmd)
		{
			var cop = new ComponentsOfPedals
			{
				PedalId = cmd.PedalId,
				ComponentId = cmd.ComponentId,
				Amount = cmd.Amount
			};
			Context.ComponentsOfPedals.Add(cop);
			Context.SaveChanges();
			var pedal = Context.Pedals.Single(x => x.Id == cmd.PedalId);
			BO.Pedals.TriggerUpdated(cmd, new BO.Pedal(pedal, pedal.ProfitMargin.HasValue? pedal.ProfitMargin.Value: Context.Config.Single().DefaultPedalProfitMargin));
			return cop.Id;
		}
	}
}
