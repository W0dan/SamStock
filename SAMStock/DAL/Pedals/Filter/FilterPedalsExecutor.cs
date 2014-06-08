using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsExecutor : RequestExecutor<FilterPedalsRequest, FilterPedalsResponse>
	{
		public FilterPedalsExecutor(IContext context) : base(context)
		{
		}

		public override FilterPedalsResponse Execute(FilterPedalsRequest req)
		{
			IQueryable<Pedal> pedals = Context.Pedals;
			req.ComponentId.IfNotNull(x => pedals = pedals.Where(y => y.ComponentsOfPedals.Any(z => z.ComponentId == x)));
			req.Id.IfNotNull(x => pedals = pedals.Where(y => y.Id == x));
			return new FilterPedalsResponse(pedals, Context.Config.Single().DefaultPedalProfitMargin);
		}
	}
}
