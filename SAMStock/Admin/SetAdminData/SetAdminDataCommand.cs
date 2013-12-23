using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Admin.SetAdminData
{
	public class SetAdminDataCommand
	{
		public Decimal? VAT { get; set; }
		public Decimal? DefaultPedalPriceMargin { get; set; }
	}
}
