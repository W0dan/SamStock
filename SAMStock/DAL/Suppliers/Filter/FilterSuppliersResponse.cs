using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

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