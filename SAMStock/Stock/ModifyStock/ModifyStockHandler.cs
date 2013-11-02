using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Stock.ModifyStock
{
	public class ModifyStockHandler:IModifyStockHandler
	{
		private IModifyStockCommandExecutor _executor;

		public ModifyStockHandler(IModifyStockCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(ModifyStockCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
