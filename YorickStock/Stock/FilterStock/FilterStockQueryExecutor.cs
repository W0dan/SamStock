using System.Linq;
using SamStock.Database;

namespace SamStock.Stock.FilterStock {
    public class FilterStockQueryExecutor : IFilterStockQueryExecutor {
        private readonly IContext _context;

        public FilterStockQueryExecutor(IContext context) {
            _context = context;
        }

        public FilterStockResponse Execute(FilterStockRequest request) {
            IQueryable<Component> tmp = _context.Component;

            if (request.LeverancierID > 0) {
                tmp = tmp.Where(component => component.LeverancierId == request.LeverancierID);
            }

            var result = tmp.Select(x => new FilterStockItem {
                Stocknr = x.Stocknr,
                Naam = x.Naam,
                Prijs = x.Prijs,
                Hoeveelheid = x.Hoeveelheid,
                MinimumStock = x.MinimumStock,
                Opmerkingen = x.Opmerkingen,
                LeverancierNaam = x.Leverancier.Naam
            }).ToList();

            return new FilterStockResponse { List = result };
        }
    }
}
