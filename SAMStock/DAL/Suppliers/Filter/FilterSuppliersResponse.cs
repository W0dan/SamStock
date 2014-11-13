using System.Collections.Generic;
using System.Linq;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersResponse: Response
	{
		public IEnumerable<Supplier> Suppliers { get; private set; }

		public FilterSuppliersResponse(IEnumerable<Database.Supplier> suppliers)
		{
			Suppliers = suppliers.Select(x => new Supplier(x));
		}
	}
}