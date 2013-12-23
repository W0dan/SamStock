using SAMStock.Utilities;

namespace SAMStock.Supplier.FilterSuppliers
{
	public interface IFilterSuppliersQueryExecutor : IQuery
	{
		FilterSuppliersResponse Execute(FilterSuppliersRequest request);
	}
}
