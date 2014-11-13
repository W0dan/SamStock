using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersExecutor : Executor<FilterSuppliersRequest, FilterSuppliersResponse>
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
