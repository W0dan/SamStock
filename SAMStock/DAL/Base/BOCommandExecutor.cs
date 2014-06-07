﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.DAL.Base
{
	public abstract class BOCommandExecutor<TCommand, TBO>: IBOCommandExecutor<TCommand, TBO> where TCommand: IBOCommand<TBO> where TBO: BO.IBO
	{
		protected readonly IContext Context;

		protected BOCommandExecutor(IContext context)
		{
			Context = context;
		}

		public abstract TBO Execute(TCommand cmd);
	}
}