using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Stock.ModifyStock
{
	public class ModifyStockCommandExecutor:IModifyStockCommandExecutor
	{
		private readonly IContext _context;

		public ModifyStockCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(ModifyStockCommand cmd)
		{	
			if (!cmd.DeleteOption)
			{
				Component c = _context.Component.Single(x => x.Id == cmd.Id);
				c.ItemCode = cmd.ItemCode;
				c.MinimumStock = cmd.MinimumStock;
				c.Name = cmd.Name;
				c.Price = cmd.Price;
				c.Stock = cmd.Quantity;
				c.Remarks = cmd.Remarks;
				c.Stocknr = cmd.Stocknr;
				c.SupplierId = _context.Supplier.Single(x => x.Name == cmd.SupplierName).Id;
				_context.SaveChanges();
			} else
			{
				if (_context.PedalComponent.Count(x => x.ComponentId == cmd.Id) == 0)
				{
					_context.Component.DeleteObject(_context.Component.Single(x => x.Id == cmd.Id));
				}
				else
				{
					throw new ComponentInUseException
					{
						PedalNames = _context.PedalComponent.Where(x => x.ComponentId == cmd.Id).Select(x => x.Pedal.Name).ToList()
					};
				}
			}
		}
	}
}
