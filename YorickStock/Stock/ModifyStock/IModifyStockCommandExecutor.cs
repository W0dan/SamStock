using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Stock.ModifyStock
{
	public interface IModifyStockCommandExecutor : IQuery
	{
		void Execute(ModifyStockCommand cmd);
	}
}
