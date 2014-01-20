using SAMStock.Utilities;

namespace SAMStock.DTO.Supplier.FilterSuppliers
{
	public interface IFilterSuppliersHandler : IQueryHandler<FilterSuppliersRequest,FilterSuppliersResponse>
	{
		new FilterSuppliersResponse Handle(FilterSuppliersRequest request);
	}
}