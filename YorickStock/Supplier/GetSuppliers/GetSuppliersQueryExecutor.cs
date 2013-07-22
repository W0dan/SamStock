using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Supplier.GetSuppliers
{
	public class GetSuppliersQueryExecutor : IGetSuppliersQueryExecutor
	{
		private readonly IContext _context;

		public GetSuppliersQueryExecutor(IContext context)
		{
			_context = context;
		}

		public GetSuppliersResponse Execute(GetSuppliersRequest request)
		{
			var result = _context.Supplier
				.Select(x => new GetSuppliersItem
				{
					Name = x.Name,
					Address = x.Address,
					Website = x.Website
				})
				.ToList();

			return new GetSuppliersResponse { Suppliers = result };
		}
	}
}
