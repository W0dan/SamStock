using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersResponse: IResponse
	{
		public List<Supplier> Suppliers { get; private set; }

		public FilterSuppliersResponse(IEnumerable<Database.Supplier> suppliers)
		{
			Suppliers = suppliers.Select(x => new Supplier(x)).ToList();
		}
	}
}