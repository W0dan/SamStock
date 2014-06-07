using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Create
{
	public class CreateComponentHandler: BOCommandHandler<CreateComponentCommand, BO.Component>
	{
		public CreateComponentHandler(IBOCommandExecutor<CreateComponentCommand, BO.Component> executor) : base(executor)
		{
		}
	}
}
