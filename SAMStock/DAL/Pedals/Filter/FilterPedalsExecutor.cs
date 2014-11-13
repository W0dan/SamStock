using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsExecutor : Executor<FilterPedalsRequest, FilterPedalsResponse>
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
