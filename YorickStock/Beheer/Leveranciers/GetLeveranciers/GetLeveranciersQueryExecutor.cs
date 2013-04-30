using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Beheer.Leveranciers.GetLeveranciers {
    public class GetLeveranciersQueryExecutor : IGetLeveranciersQueryExecutor {
        private readonly IContext _context;

        public GetLeveranciersQueryExecutor(IContext context) {
            _context = context;
        }

        public GetLeveranciersResponse Execute(GetLeveranciersRequest request) {
            var result = _context.Component
                .Select(x => new GetLeveranciersItem {
                    Naam = x.Naam
                })
                .ToList();

            return new GetLeveranciersResponse { List = result };
        }
    }
}
