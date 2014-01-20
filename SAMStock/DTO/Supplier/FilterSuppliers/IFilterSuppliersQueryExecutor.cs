using SAMStock.Utilities;

namespace SAMStock.DTO.Supplier.FilterSuppliers
{
	public interface IFilterSuppliersQueryExecutor : IQuery
	{
		FilterSuppliersResponse Execute(FilterSuppliersRequest request);
	}
}
