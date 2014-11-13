using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersRequest: Request<FilterSuppliersResponse>
	{
		public FilterSuppliersRequest(object s) : base(s)
		{
		}

		public int? Id { get; set; }
		public int? ComponentId { get; set; }
	}
}
