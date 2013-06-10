using System.Linq;
using SamStock.Database;

namespace SamStock.Stock.UpdateStock
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
            foreach (var su in command.List)
            {
                if (su.Amount == 0) continue;

                var comp = _context.Component.Single(u => u.Stocknr == su.Stocknr);

                if (comp.Hoeveelheid + su.Amount == 0)
                {
                    comp.Hoeveelheid = 0;
                    continue;
                }

                var avgPrice = (comp.Hoeveelheid * comp.Prijs + su.Amount * su.Price) / (comp.Hoeveelheid + su.Amount);
                comp.Prijs = avgPrice;

                comp.Hoeveelheid += su.Amount;
            }
        }
    }
}