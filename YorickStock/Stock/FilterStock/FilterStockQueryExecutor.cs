using System.Linq;
using SamStock.Database;

namespace SamStock.Stock.FilterStock {
    public class FilterStockQueryExecutor : IFilterStockQueryExecutor {
        private readonly IContext _context;

        public FilterStockQueryExecutor(IContext context) {
            _context = context;
        }

        public FilterStockResponse Execute(FilterStockRequest request) {
            IQueryable<Component> query = _context.Component;

            if (request.LeverancierID > 0)
                query = query.Where(component => component.LeverancierId == request.LeverancierID);
            if (!string.IsNullOrEmpty(request.StockNr))
                query = query.Where(component => component.Stocknr.StartsWith(request.StockNr));
            if (request.Manco == true)
                query = query.Where(component => component.Hoeveelheid < component.MinimumStock);

            query = query.OrderBy(c => c.Stocknr);
            var result = query.Select(x => new FilterStockItem {
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
