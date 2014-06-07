﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Pedals.Delete
{
	public class DeletePedalExecutor: CommandExecutor<DeletePedalCommand>
	{
		public DeletePedalExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(DeletePedalCommand cmd)
		{
			var pedal = Context.Pedals.Single(x => x.Id == cmd.Id);
			Context.Pedals.Remove(pedal);
			Context.SaveChanges();
			return pedal.Id;
		}
	}
}