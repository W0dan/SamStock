using System;

namespace SAMStock.DAL.Admin.SetAdminData
{
	public class SetAdminDataCommand
	{
		public Decimal? VAT { get; set; }
		public Decimal? DefaultPedalPriceMargin { get; set; }
	}
}
