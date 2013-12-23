using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.Pedal.FilterPedal
{
    public class FilterPedalQueryExecutor : IFilterPedalQueryExecutor
    {
        private readonly IContext _context;

        public FilterPedalQueryExecutor(IContext context)
        {
            _context = context;
        }

        public FilterPedalResponse Execute(FilterPedalRequest request)
        {
			var defaultpedalpricemargin = _context.AdminData.Single().DefaultPedalPriceMargin;

			IQueryable<SAMStock.Database.Pedal> pedals = _context.Pedal;
	        if (request.Id.HasValue) pedals = pedals.Where(x => x.Id == request.Id.Value);
	        if (!request.Name.IsNullOrEmpty()) pedals = pedals.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

			return new FilterPedalResponse
			{
				Pedals = _context.Pedal.Select(x => new FilterPedalResponsePedal
				{
					Id = x.Id,
					Name = x.Name,
					Price = x.Price,
					Margin = x.Margin ?? defaultpedalpricemargin
				}).ToList()
			};
        }
    }
}