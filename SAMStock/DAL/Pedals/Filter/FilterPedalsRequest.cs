using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Pedals.Filter
{
	public class FilterPedalsRequest: IRequest
	{
		public int? Id { get; set; }
		public int? ComponentId { get; set; }
		public int? SupplierId { get; set; }
	}
}
