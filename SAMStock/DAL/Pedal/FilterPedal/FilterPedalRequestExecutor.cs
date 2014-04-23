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

	        foreach (var pedal in resp.Pedals)
	        {
				pedal.Components =
					Context.PedalComponent.Where(x => x.PedalId == pedal.Id).Select(x => new FilterPedalResponseComponent
					{
						Id = x.Id,
						Quantity = x.Number
					}).ToList();
	        }
	        return resp;
        }
    }
}