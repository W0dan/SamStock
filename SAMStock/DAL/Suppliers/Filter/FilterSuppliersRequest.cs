using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Suppliers.Filter
{
	public class FilterSuppliersRequest: IRequest
	{
		public int? ComponentId { get; set; }
		public int? SupplierId { get; set; }
	}
}
