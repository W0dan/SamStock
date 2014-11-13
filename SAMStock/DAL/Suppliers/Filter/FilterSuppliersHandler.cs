using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersHandler : Handler<FilterSuppliersRequest, FilterSuppliersResponse>
	{
		public FilterSuppliersHandler(IExecutor<FilterSuppliersRequest, FilterSuppliersResponse> executor) : base(executor)
		{
		}
	}
}
