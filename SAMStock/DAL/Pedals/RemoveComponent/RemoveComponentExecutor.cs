using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;

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
			return cop.Id;
		}
	}
}
