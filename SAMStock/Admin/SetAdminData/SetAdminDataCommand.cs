using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Admin.SetAdminData
{
	public class SetAdminDataCommand
	{
		public Decimal VAT;
		public Decimal DefaultPedalPriceMargin;

		public SetAdminDataCommand()
		{}

		public SetAdminDataCommand(Decimal vat, Decimal margin)
		{
			VAT = vat;
			DefaultPedalPriceMargin = margin;
		}
	}
}
