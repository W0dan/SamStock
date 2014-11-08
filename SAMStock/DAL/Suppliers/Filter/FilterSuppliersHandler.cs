using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersHandler : RequestHandler<FilterSuppliersRequest, FilterSuppliersResponse>
	{
		public FilterSuppliersHandler(IRequestExecutor<FilterSuppliersRequest, FilterSuppliersResponse> executor) : base(executor)
		{
		}
	}
}
