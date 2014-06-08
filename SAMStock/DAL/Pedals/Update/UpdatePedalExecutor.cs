using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;
using Pedal = SAMStock.BO.Pedal;

namespace SAMStock.DAL.Pedals.Update
{
	public class UpdatePedalExecutor: BOCommandExecutor<UpdatePedalCommand, BO.Pedal>
	{
		public UpdatePedalExecutor(IContext context) : base(context)
		{
		}

		public override Pedal Execute(UpdatePedalCommand cmd)
		{
			var pedal = Context.Pedals.Single(x => x.Id == cmd.Id);
			cmd.Name.IfMeaningful(x => pedal.Name = x);
			cmd.Price.IfNotNull(x => pedal.Price = x);
			cmd.ProfitMargin.IfNotNull(x => pedal.ProfitMargin = x);
			Context.SaveChanges();
			var p = new Pedal(pedal, Context.Config.Single().DefaultPedalProfitMargin);
			BO.Pedals.TriggerUpdated(cmd, p);
			return p;
		}
	}
}
