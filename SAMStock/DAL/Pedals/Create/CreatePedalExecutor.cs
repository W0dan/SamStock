using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using Pedal = SAMStock.BO.Pedal;

namespace SAMStock.DAL.Pedals.Create
{
	public class CreatePedalExecutor: BOCommandExecutor<CreatePedalCommand, Pedal>
	{
		public CreatePedalExecutor(IContext context) : base(context)
		{
		}

		public override Pedal Execute(CreatePedalCommand cmd)
		{
			var pedal = new Database.Pedal
			{
				Name = cmd.Name,
				Price = cmd.Price,
				ProfitMargin = cmd.ProfitMargin
			};
			Context.Pedals.Add(pedal);
			Context.SaveChanges();
			var p = new Pedal(pedal, Context.Config.Single().DefaultPedalProfitMargin);
			BO.Pedals.Manager.TriggerCreated(p);
			return p;
		}
	}
}
