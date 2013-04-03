﻿using System.Linq;
using SamStock.Database;

namespace SamStock.Stock.GetStockOverzicht
{
    public class GetStockOverzichtQueryExecutor : IGetStockOverzichtQueryExecutor
    {
        private readonly IContext _context;

        public GetStockOverzichtQueryExecutor(IContext context)
        {
            _context = context;
        }

        public GetStockOverzichtResponse Execute(GetStockOverzichtRequest request)
        {
            var result = _context.Component
                .Select(x => new GetStockOverzichtItem
                    {
                        Stocknr = x.Stocknr, 
                        Naam = x.Naam, 
                        Prijs = x.Prijs, 
                        Hoeveelheid = x.Hoeveelheid,
                        MinimumStock = x.MinimumStock,
                        Opmerkingen = x.Opmerkingen,
                        LeverancierNaam = x.Leverancier.Naam
                    })
                .ToList();

            return new GetStockOverzichtResponse { List = result };
        }
    }
}