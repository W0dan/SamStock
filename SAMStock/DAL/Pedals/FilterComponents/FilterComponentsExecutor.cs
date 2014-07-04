using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Pedals.FilterComponents
{
	public class FilterComponentsExecutor: RequestExecutor<FilterComponentsRequest, FilterComponentsResponse>
	{
		public FilterComponentsExecutor(IContext context) : base(context)
		{
		}

		public override FilterComponentsResponse Execute(FilterComponentsRequest req)
		{
			IQueryable<ComponentsOfPedals> cop = Context.ComponentsOfPedals;
			req.PedalId.IfNotNull(x => cop = cop.Where(y => y.PedalId == x));
			req.ComponentId.IfNotNull(x => cop = cop.Where(y => y.ComponentId == x));
			return new FilterComponentsResponse(cop);
		}
	}
}
