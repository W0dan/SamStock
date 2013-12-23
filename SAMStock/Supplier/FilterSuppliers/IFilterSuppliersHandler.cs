using SAMStock.Utilities;

namespace SAMStock.Supplier.FilterSuppliers
{
	public interface IFilterSuppliersHandler : IQueryHandler<FilterSuppliersRequest,FilterSuppliersResponse>
	{
		new FilterSuppliersResponse Handle(FilterSuppliersRequest request);
	}
}