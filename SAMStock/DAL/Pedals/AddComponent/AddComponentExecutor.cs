using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Base;
using SAMStock.Database;
using Pedal = SAMStock.BO.Pedal;

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
			return cop.Id;
		}
	}
}
