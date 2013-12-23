using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.Component.UpdateStock
{
	public class UpdateStockCommandExecutor: IUpdateStockCommandExecutor
	{
		private readonly IContext _context;

		public UpdateStockCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdateStockCommand cmd)
		{
			var comp = _context.Component.Single(x => x.Id == cmd.Id);
			if (!cmd.ItemCode.IsNullOrEmpty()) comp.ItemCode = cmd.ItemCode;
			if (!cmd.Name.IsNullOrEmpty()) comp.Name = cmd.Name;
			if (!cmd.Remarks.IsNullOrEmpty()) comp.Remarks = cmd.Remarks;
			if (!cmd.Stocknr.IsNullOrEmpty()) comp.Stocknr = cmd.Stocknr;
			if (cmd.MinimumStock.HasValue) comp.MinimumStock = cmd.MinimumStock.Value;
			if (cmd.Price.HasValue) comp.Price = cmd.Price.Value;
			if (cmd.Quantity.HasValue) comp.Stock = cmd.Quantity.Value;
			if (cmd.SupplierId.HasValue) comp.SupplierId = cmd.SupplierId.Value;
		}
	}
}
