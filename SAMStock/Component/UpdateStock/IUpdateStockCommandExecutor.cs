using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Component.UpdateStock
{
	public interface IUpdateStockCommandExecutor : IQuery
	{
		void Execute(UpdateStockCommand cmd);
	}
}
