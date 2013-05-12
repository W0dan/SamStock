using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Stock.FindMancos {
    public class FindMancosQueryExecutor : IFindMancosQueryExecutor {
        private readonly IContext _context;

        public FindMancosQueryExecutor(IContext context) {
            _context = context;
        }

        public FindMancosResponse Execute(FindMancosRequest request) {
            IQueryable<Component> query = _context.Component;
            query.Where(component => component.Hoeveelheid < component.MinimumStock);

            var result = query.Select(x => new FindMancosItem {
                Stocknr = x.Stocknr,
                Naam = x.Naam,
                Prijs = x.Prijs,
                Hoeveelheid = x.Hoeveelheid,
                MinimumStock = x.MinimumStock,
                Opmerkingen = x.Opmerkingen,
                LeverancierNaam = x.Leverancier.Naam
            }).ToList();

            return new FindMancosResponse { List = result };
        }
    }
}
