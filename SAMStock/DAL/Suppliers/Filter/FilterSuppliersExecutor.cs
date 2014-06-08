using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersExecutor : RequestExecutor<FilterSuppliersRequest, FilterSuppliersResponse>
	{
		public FilterSuppliersExecutor(IContext context) : base(context)
		{
		}

		public override FilterSuppliersResponse Execute(FilterSuppliersRequest req)
		{
			IQueryable<Supplier> suppliers = Context.Suppliers;
			req.ComponentId.IfNotNull(x => suppliers = suppliers.Where(y => y.Components.Any(z => z.Id == x)));
			req.Id.IfNotNull(x => suppliers = suppliers.Where(y => y.Id == x));
			return new FilterSuppliersResponse(suppliers);
		}
	}
}
