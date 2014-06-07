using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			return cop.Id;
		}
	}
}
