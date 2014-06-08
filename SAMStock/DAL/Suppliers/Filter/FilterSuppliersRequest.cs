using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersRequest: IFilterRequest<Supplier>
	{
		public int? Id { get; set; }
		public int? ComponentId { get; set; }
	}
}
