using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Update
{
	public class UpdateComponentHandler: BOCommandHandler<UpdateComponentCommand, BO.Component>
	{
		public UpdateComponentHandler(IBOCommandExecutor<UpdateComponentCommand, BO.Component> executor) : base(executor)
		{
		}
	}
}
