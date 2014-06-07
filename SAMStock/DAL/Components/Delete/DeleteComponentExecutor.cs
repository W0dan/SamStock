﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using SAMStock.DAL.Base;
using SAMStock.DAL.Exceptions;
using SAMStock.Database;

namespace SAMStock.DAL.Components.Delete
{
	public class DeleteComponentExecutor: CommandExecutor<DeleteComponentCommand>
	{
		public DeleteComponentExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(DeleteComponentCommand cmd)
		{
			var component = Context.Components.Single(x => x.Id == cmd.Id);
			if (component.ComponentsOfPedals.Any())
			{
				if (cmd.Cascade)
				{
					component.ComponentsOfPedals.ForEach(x => Context.ComponentsOfPedals.Remove(x));
				}
				else
				{
					throw new ForeignKeyException(component.Id, component.ComponentsOfPedals.Select(x => x.Id), "ComponentsOfPedals");
				}
			}
			Context.SaveChanges();
			Context.Components.Remove(component);
			Context.SaveChanges();
			return component.Id;
		}
	}
}