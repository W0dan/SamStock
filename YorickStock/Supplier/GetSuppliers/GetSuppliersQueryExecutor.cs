using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Supplier.GetSuppliers
{
    public class GetSuppliersQueryExecutor : IGetSuppliersQueryExecutor
    {
        private readonly IContext _context;

        public GetSuppliersQueryExecutor(IContext context)
        {
            _context = context;
        }

        public GetSuppliersResponse Execute(GetSuppliersRequest request)
        {
            var result = _context.Leverancier
                .Select(x => new GetSuppliersItem
                {
                    Naam = x.Naam,
                    Adres = x.Adres,
                    Website = x.Site
                })
                .ToList();

            return new GetSuppliersResponse { List = result };
        }
    }
}
