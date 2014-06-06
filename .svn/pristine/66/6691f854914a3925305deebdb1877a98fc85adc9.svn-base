using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.DAL.Pedal.FilterComponent
{
	public class FilterComponentExecutor: RequestExecutor<FilterComponentRequest, FilterComponentResponse>
	{
		public FilterComponentExecutor(IContext context): base(context)
		{
		}

		public override FilterComponentResponse Execute(FilterComponentRequest req)
		{
			IQueryable<Database.Component> comp = Context.Component;
			if (req.PedalId.HasValue) comp = comp.Where(x => Context.PedalComponent.Where(y => y.PedalId == req.PedalId).Select(y => y.ComponentId).Contains(x.Id));

			return new FilterComponentResponse
			{
				Components = comp.Select(x => new FilterComponentResponseComponent
				{
					Stocknr = x.Stocknr,
					Name = x.Name,
					Price = x.Price,
					Stock = x.Stock,
					MinimumStock = x.MinimumStock,
					Remark = x.Remarks,
					Id = x.Id,
					ItemCode = x.ItemCode,
					SupplierId = x.SupplierId,
					Quantity = Context.PedalComponent.Single(y => y.ComponentId == x.Id && y.PedalId == req.PedalId).Number
				}).ToList()
			};
		}
	}
}
