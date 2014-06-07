﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsExecutor: RequestExecutor<FilterComponentsRequest, FilterComponentsResponse>
	{
		public FilterComponentsExecutor(IContext context) : base(context)
		{
		}

		public override FilterComponentsResponse Execute(FilterComponentsRequest req)
		{
			IQueryable<Component> components = Context.Components;
			req.Id.IfNotNull(x => components.FilterBy(y => y.Id == x));
			req.PedalId.IfNotNull(x => components.FilterBy(y => y.ComponentsOfPedals.Any(z => z.PedalId == x)));
			req.Shortage.IfNotNull(x => components.FilterBy(y => y.Stock < y.MinimumStock));
			req.StockHigherThan.IfNotNull(x => components.FilterBy(y => y.Stock > x));
			req.StockLowerThan.IfNotNull(x => components.FilterBy(y => y.Stock < x));
			req.SupplierId.IfNotNull(x => components.FilterBy(y => y.SupplierId == x));
			return new FilterComponentsResponse(components);
		}
	}
}