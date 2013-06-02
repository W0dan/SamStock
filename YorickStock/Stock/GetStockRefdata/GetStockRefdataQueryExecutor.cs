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
            var leveranciers = _context.Leverancier
                .Select(x => new LeverancierRefdata { Id = x.Id, Naam = x.Naam });

            return new GetStockRefdataResponse { Leveranciers = leveranciers };
        }
    }
}