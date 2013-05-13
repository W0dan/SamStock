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

        public FindMancosResponse Execute(FindMancosRequest request)
        {
            var query = _context.Component
                        .Where(component => component.Hoeveelheid < component.MinimumStock)
                        .Select(x => new FindMancosItem
                            {
                                Stocknr = x.Stocknr,
                                Naam = x.Naam,
                                Prijs = x.Prijs,
                                Hoeveelheid = x.Hoeveelheid,
                                MinimumStock = x.MinimumStock,
                                Opmerkingen = x.Opmerkingen,
                                LeverancierNaam = x.Leverancier.Naam
                            });

            return new FindMancosResponse { List = query.ToList() };
        }
    }
}
