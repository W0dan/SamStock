using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;
using SamStock.Stock.GetStockOverzicht;

namespace SamStock.Stock.FilterStock {
    class FilterStockQueryExecutor : IFilterStockQueryExecutor {
        private readonly IContext _context;

        public FilterStockQueryExecutor(IContext context) {
            _context = context;
        }

        public FilterStockResponse Execute(FilterStockRequest request) {
            var result = _context.Component
                .Select(x => new FilterStockItem {
                    Stocknr = x.Stocknr,
                    Naam = x.Naam,
                    Prijs = x.Prijs,
                    Hoeveelheid = x.Hoeveelheid,
                    MinimumStock = x.MinimumStock,
                    Opmerkingen = x.Opmerkingen,
                    LeverancierNaam = x.Leverancier.Naam
                })
                // .Where(request.LeverancierID ... )
                .ToList();

            return new FilterStockResponse { List = result };
        }
    }
}
