using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using SAMStock.Utilities;
using Util;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsExecutor : RequestExecutor<FilterComponentsRequest, FilterComponentsResponse>
	{
		public FilterComponentsExecutor(IContext context) : base(context)
		{
		}

		public override FilterComponentsResponse Execute(FilterComponentsRequest req)
		{
			IQueryable<Component> components = Context.Components;
			req.Id.IfNotNull(x => components = components.Where(y => y.Id == x));
			req.PedalId.IfNotNull(x => components = components.Where(y => y.ComponentsOfPedals.Any(z => z.PedalId == x)));
			req.Shortage.IfNotNull(x => components = components.Where(y => y.Stock < y.MinimumStock));
			req.StockHigherThan.IfNotNull(x => components = components.Where(y => y.Stock > x));
			req.StockLowerThan.IfNotNull(x => components = components.Where(y => y.Stock < x));
			req.SupplierId.IfNotNull(x => components = components.Where(y => y.SupplierId == x));
			return new FilterComponentsResponse(components);
		}
	}
}