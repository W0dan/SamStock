using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;
using SAMStock.DAL.Base;
using SAMStock.DAL.Config.GetConfig;

namespace SAMStock
{
	public class BOCommandExecuted: EventArgs
	{
		public IBO BO { get; private set; }

		public Type BOType { get; private set; }

		public BOCommandExecuted(IBO bo)
		{
			BO = bo;
			BOType = bo.GetType();
		}
	}
}
