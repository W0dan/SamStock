using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using SAMStock.Database;

namespace SAMStock.DAL.Pedal.FilterPedal
{
	public class FilterPedalRequestExecutor : RequestExecutor<FilterPedalRequest, FilterPedalResponse>
    {
        public FilterPedalRequestExecutor(IContext context):base(context)
        {
        }

        public override FilterPedalResponse Execute(FilterPedalRequest request)
        {
	        var defaultMargin = Context.AdminData.Single().DefaultPedalPriceMargin;

			IQueryable<Database.Pedal> pedals = Context.Pedal;
	        if (request.Id.HasValue) pedals = pedals.Where(x => x.Id == request.Id.Value);
	        if (!string.IsNullOrWhiteSpace(request.Name))
	        {
		        pedals = pedals.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
	        }

			var componentids = Context.PedalComponent
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