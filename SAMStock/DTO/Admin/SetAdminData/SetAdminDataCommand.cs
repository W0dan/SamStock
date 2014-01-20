using System;

namespace SAMStock.DTO.Admin.SetAdminData
{
	public class SetAdminDataCommand
	{
		public Decimal? VAT { get; set; }
		public Decimal? DefaultPedalPriceMargin { get; set; }
	}
}
