using System.Linq;
using SAMStock.Database;

namespace SAMStock.Stock.FilterStock
{
	public class FilterStockQueryExecutor : IFilterStockQueryExecutor
	{
		private readonly IContext _context;

		public FilterStockQueryExecutor(IContext context)
		{
			_context = context;
		}

		public FilterStockResponse Execute(FilterStockRequest request)
		{
			IQueryable<Component> query = _context.Component;

			if (request.SupplierId > 0)
				query = query.Where(component => component.SupplierId == request.SupplierId);
			if (!string.IsNullOrEmpty(request.StockNr))
				query = query.Where(component => component.Stocknr.ToLower().StartsWith(request.StockNr.ToLower()));
			if (request.Manco == true)
				query = query.Where(component => component.Stock < component.MinimumStock);

			query = query.OrderBy(c => c.Stocknr);
			var result = query.Select(x => new FilterStockItem
			{
				Stocknr = x.Stocknr,
				Name = x.Name,
				Price = x.Price,
				Quantity = x.Stock,
				MinimumStock = x.MinimumStock,
				Remark = x.Remarks,
				SupplierName = x.Supplier.Name,
				Id = x.Id,
				ItemCode = x.ItemCode
			}).ToList();

			return new FilterStockResponse { Components = result };
		}
	}
}
