using System.Collections.Generic;
using System.Linq;
using SAMStock.BO;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersResponse: IFilterResponse<Supplier>
	{
		public IEnumerable<Supplier> Items { get; private set; }

		public FilterSuppliersResponse(IEnumerable<Database.Supplier> suppliers)
		{
			Items = suppliers.Select(x => new Supplier(x));
		}
	}
}