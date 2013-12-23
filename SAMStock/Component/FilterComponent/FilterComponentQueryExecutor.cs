using System.Linq;
using SAMStock.Database;

namespace SAMStock.Component.FilterComponent
{
	public class FilterComponentQueryExecutor : IFilterComponentQueryExecutor
	{
		private readonly IContext _context;

		public FilterComponentQueryExecutor(IContext context)
		{
			_context = context;
		}

		public FilterComponentResponse Execute(FilterComponentRequest request)
		{
			IQueryable<Database.Component> query = _context.Component;

			if (request.SupplierId.HasValue) query = query.Where(x => x.Supplier.Id == request.SupplierId.Value);
			if (request.ComponentId.HasValue) query = query.Where(component => component.Id == request.ComponentId.Value);
			if (!string.IsNullOrEmpty(request.StockNr)) query = query.Where(component => component.Stocknr.ToLower().Contains(request.StockNr.ToLower()));
			if (request.Shortage) query = query.Where(component => component.Stock < component.MinimumStock);

			query = query.OrderBy(c => c.ItemCode);
			return new FilterComponentResponse
			{
				Components = query.Select(x => new FilterComponentItem
				{
					Stocknr = x.Stocknr,
					Name = x.Name,
					Price = x.Price,
					Quantity = x.Stock,
					MinimumStock = x.MinimumStock,
					Remark = x.Remarks,
					Id = x.Id,
					ItemCode = x.ItemCode
				}).ToList()
			};
		}
	}
}
