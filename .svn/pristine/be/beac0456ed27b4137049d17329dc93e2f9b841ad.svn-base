using System.Collections.Generic;
using System.Linq;
using SAMStock.Database;

namespace SAMStock.DAL.Component.FilterComponent
{
	public class FilterComponentRequestExecutor : RequestExecutor<FilterComponentRequest, FilterComponentResponse>
	{
		public FilterComponentRequestExecutor(IContext context): base(context)
		{
		}

		public override FilterComponentResponse Execute(FilterComponentRequest request)
		{
			IQueryable<Database.Component> query = Context.Component;

			if (request.SupplierId.HasValue) query = query.Where(x => x.Supplier.Id == request.SupplierId.Value);
			if (request.ComponentId.HasValue) query = query.Where(x => x.Id == request.ComponentId.Value);
			if (!string.IsNullOrWhiteSpace(request.StockNr)) query = query.Where(x => x.Stocknr.ToLower().Contains(request.StockNr.ToLower()));
			if (request.Shortage) query = query.Where(x => x.Stock < x.MinimumStock);
			if (request.Ids.Any()) query = query.Where(x => request.Ids.Contains(x.Id));
			if (request.PedalId.HasValue)
			{
				var ids = Context.PedalComponent.Where(y => y.PedalId == request.PedalId).Select(y => y.ComponentId).ToList();
				query = query.Where(x => ids.Contains(x.Id));
			}

			var resp = new FilterComponentResponse
			{
				Components = query.Select(x => new FilterComponentResponseComponent
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

			foreach (var component in resp.Components)
			{
				component.Pedals = Context.PedalComponent.Where(x => x.ComponentId == component.Id).Select(x => new FilterComponentResponsePedal
				{
					PedalId = x.PedalId,
					Quantity = x.Number
				}).ToList();
			}
			return resp;
		}
	}
}
