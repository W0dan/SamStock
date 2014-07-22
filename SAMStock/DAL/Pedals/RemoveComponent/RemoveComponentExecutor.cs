﻿using System.Linq;
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
			var pedal = Context.Pedals.Single(x => x.Id == cmd.PedalId);
			return cop.Id;
		}
	}
}
