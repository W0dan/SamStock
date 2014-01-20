using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.DTO.Pedal.FilterPedal
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
	        var defaultMargin = _context.AdminData.Single().DefaultPedalPriceMargin;

			IQueryable<Database.Pedal> pedals = _context.Pedal;
	        if (request.Id.HasValue) pedals = pedals.Where(x => x.Id == request.Id.Value);
	        if (!string.IsNullOrWhiteSpace(request.Name))
	        {
		        pedals = pedals.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
	        }

			var componentids = _context.PedalComponent
				.Select(x => new { x.PedalId, x.ComponentId })
				.GroupBy(x => x.PedalId)
				.ToList()
				.Select(x => new { PedalId = x.Key, ComponentIds = x.Select(y => y.ComponentId).ToList() })
				.ToDictionary(x => x.PedalId, x => x.ComponentIds);

			var resp = new FilterPedalResponse
			{
				Pedals = pedals.Select(x => new FilterPedalResponsePedal
				{
					Id = x.Id,
					Name = x.Name,
					Price = x.Price,
					Margin = x.Margin,
					DefaultMargin = defaultMargin
				}).ToList()
			};
	        foreach (var item in resp.Pedals)
	        {
		        List<int> ids;
				if (componentids.TryGetValue(item.Id, out ids))
		        {
			        item.ComponentIds = ids;
		        }
	        }
	        return resp;
        }
    }
}