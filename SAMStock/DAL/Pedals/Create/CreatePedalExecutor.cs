using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Pedals.Create
{
	public class CreatePedalExecutor: BOCommandExecutor<CreatePedalCommand, BO.Pedal>
	{
		public CreatePedalExecutor(IContext context) : base(context)
		{
		}

		public override BO.Pedal Execute(CreatePedalCommand cmd)
		{
			var pedal = new Pedal
			{
				Name = cmd.Name,
				Price = cmd.Price,
				ProfitMargin = cmd.ProfitMargin
			};
			Context.Pedals.Add(pedal);
			Context.SaveChanges();
			var p = new BO.Pedal(pedal, Context.Config.Single().DefaultPedalProfitMargin);
			BO.Pedals.TriggerCreated(cmd, p);
			return p;
		}
	}
}
