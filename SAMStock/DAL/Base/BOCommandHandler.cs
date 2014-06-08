using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public abstract class BOCommandHandler<TBOCommand, TBO> : IBOCommandHandler<TBOCommand, TBO> where TBOCommand: IBOCommand<TBO> where TBO: IBO
	{
		protected readonly IBOCommandExecutor<TBOCommand, TBO> Executor;

		protected BOCommandHandler(IBOCommandExecutor<TBOCommand, TBO> executor)
		{
			Executor = executor;
		}

		public TBO Handle(TBOCommand cmd)
		{
			return Executor.Execute(cmd);
		}
	}
}
