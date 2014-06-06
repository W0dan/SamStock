using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;

namespace SAMStock.DAL.Components.Filter
{
	public class FilterComponentsRequest: IRequest
	{
		public int? Id { get; set; }
		public int? PedalId { get; set; }
		public int? StockLowerThan { get; set; }
		public int? StockHigherThan { get; set; }
		public bool? Shortage { get; set; }
	}
}