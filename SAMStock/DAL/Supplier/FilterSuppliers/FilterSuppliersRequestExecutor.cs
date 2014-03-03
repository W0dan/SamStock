using System.Collections.Generic;
using System.Linq;
using SAMStock.Database;

namespace SAMStock.DAL.Supplier.FilterSuppliers
{
	public class FilterSuppliersRequestExecutor : RequestExecutor<FilterSuppliersRequest, FilterSuppliersResponse>
	{
		public FilterSuppliersRequestExecutor(IContext context): base(context)
		{
		}

		public override FilterSuppliersResponse Execute(FilterSuppliersRequest request)
		{
			IEnumerable<Database.Supplier> suppliers = Context.Supplier;
			if (request.Id.HasValue) suppliers = suppliers.Where(x => x.Id == request.Id.Value);
			return new FilterSuppliersResponse
			{
				Suppliers = suppliers.Select(x => new FilterSuppliersResponseItem
				{
					Name = x.Name,
					Website = x.Website,
					Address = x.Address,
					Id = x.Id
				}).ToList()
			};
		}
	}
}
