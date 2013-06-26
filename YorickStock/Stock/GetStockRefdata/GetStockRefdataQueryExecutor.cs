using System.Linq;
using SamStock.Database;

namespace SamStock.Stock.GetStockRefdata
{
    public class GetStockRefdataQueryExecutor : IGetStockRefdataQueryExecutor
    {
        private readonly IContext _context;

        public GetStockRefdataQueryExecutor(IContext context)
        {
            _context = context;
        }

        public GetStockRefdataResponse Execute(GetStockRefdataRequest request)
        {
            var leveranciers = _context.Supplier
                .Select(x => new SupplierRefdata { Id = x.Id, Name = x.Name });

            return new GetStockRefdataResponse { Suppliers = leveranciers };
        }
    }
}