using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Stock.ModifyStock
{
	public class ModifyStockCommandExecutor:IModifyStockCommandExecutor
	{
		private IContext _context;

		public ModifyStockCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(ModifyStockCommand cmd)
		{	
			if (!cmd.DeleteOption)
			{
				Component c = _context.Component.Where(x => x.Id == cmd.Id).Single();
				c.ItemCode = cmd.ItemCode;
				c.MinimumStock = cmd.MinimumStock;
				c.Name = cmd.Name;
				c.Price = cmd.Price;
				c.Stock = cmd.Quantity;
				c.Remarks = cmd.Remarks;
				c.Stocknr = cmd.Stocknr;
				c.SupplierId = _context.Supplier.Where(x => x.Name == cmd.SupplierName).Single().Id;
				_context.SaveChanges();
			} else
			{
				if (_context.PedalComponent.Where(x => x.ComponentId == cmd.Id).Count() == 0)
				{
					_context.Component.DeleteObject(_context.Component.Where(x => x.Id == cmd.Id).Single());
				}
			}
		}
	}
}
