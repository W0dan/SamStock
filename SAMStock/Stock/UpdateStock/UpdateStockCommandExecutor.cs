using System.Linq;
using SAMStock.Database;

namespace SAMStock.Stock.UpdateStock
{
	public class UpdateStockCommandExecutor : IUpdateStockCommandExecutor
	{
		private readonly IContext _context;

		public UpdateStockCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(UpdateStockCommand command)
		{
			foreach (var su in command.StockUpdates)
			{
				if (su.Quantity == 0)
				{
					continue;
				}

				var comp = _context.Component.Single(u => u.Stocknr == su.Stocknr);

				if (comp.Stock + su.Quantity == 0)
				{
					comp.Stock = 0;
					continue;
				}

				var avgPrice = (comp.Stock * comp.Price + su.Quantity * su.Price) / (comp.Stock + su.Quantity);
				comp.Price = avgPrice;

				comp.Stock += su.Quantity;
			}
		}
	}
}