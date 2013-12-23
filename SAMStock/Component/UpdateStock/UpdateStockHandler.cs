using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.UpdateStock
{
	public class UpdateStockHandler:IUpdateStockHandler
	{
		private readonly IUpdateStockCommandExecutor _executor;

		public UpdateStockHandler(IUpdateStockCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(UpdateStockCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
