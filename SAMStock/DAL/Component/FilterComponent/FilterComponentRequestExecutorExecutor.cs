﻿using System.Collections.Generic;
using System.Linq;
using SAMStock.Database;

namespace SAMStock.DAL.Component.FilterComponent
{
	public class FilterComponentRequestExecutorExecutor : RequestExecutor<FilterComponentRequest, FilterComponentResponse>
	{
		public FilterComponentRequestExecutorExecutor(IContext context): base(context)
		{
		}

		public override FilterComponentResponse Execute(FilterComponentRequest request)
		{
			IQueryable<Database.Component> query = Context.Component;

			if (request.SupplierId.HasValue) query = query.Where(x => x.Supplier.Id == request.SupplierId.Value);
			if (request.ComponentId.HasValue) query = query.Where(x => x.Id == request.ComponentId.Value);
			if (!string.IsNullOrWhiteSpace(request.StockNr)) query = query.Where(x => x.Stocknr.ToLower().Contains(request.StockNr.ToLower()));
			if (request.Shortage) query = query.Where(x => x.Stock < x.MinimumStock);

			var pedalids = Context.PedalComponent
				.Select(x => new { x.ComponentId, x.PedalId })
				.GroupBy(x => x.ComponentId)
				.ToList()
				.Select(x => new { ComponentId = x.Key, PedalIds = x.Select(y => y.PedalId).ToList()})
				.ToDictionary(x => x.ComponentId, x => x.PedalIds);

			var resp = new FilterComponentResponse
			{
				Components = query.Select(x => new FilterComponentResponseItem
				{
					Stocknr = x.Stocknr,
					Name = x.Name,
					Price = x.Price,
					Quantity = x.Stock,
					MinimumStock = x.MinimumStock,
					Remark = x.Remarks,
					Id = x.Id,
					ItemCode = x.ItemCode,
					SupplierId = x.SupplierId
				}).ToList()
			};
			foreach (var item in resp.Components)
			{
				List<int> ids;
				if (pedalids.TryGetValue(item.Id, out ids))
				{
					item.PedalIds = ids;
				}
			}
			return resp;
		}
	}
}