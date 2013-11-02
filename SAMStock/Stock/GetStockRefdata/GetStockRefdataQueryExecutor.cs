using System.Linq;
using SAMStock.Database;

namespace SAMStock.Stock.GetStockRefdata
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