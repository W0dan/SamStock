using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Supplier.FilterSuppliers
{
	public class FilterSuppliersQueryExecutor : IFilterSuppliersQueryExecutor
	{
		private readonly IContext _context;

		public FilterSuppliersQueryExecutor(IContext context)
		{
			_context = context;
		}

		public FilterSuppliersResponse Execute(FilterSuppliersRequest request)
		{
			IEnumerable<Database.Supplier> suppliers = _context.Supplier;
			if (request.Id.HasValue) suppliers = suppliers.Where(x => x.Id == request.Id.Value);
			return new FilterSuppliersResponse
			{
				Suppliers = suppliers.Select(x => new FilterSuppliersResponseItem
				{
					Name = x.Name,
					Website = x.Website,
					Address = x.Address
				}).ToList()
			};
		}
	}
}
