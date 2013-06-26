using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Admin.GetAdminData
{
	public class GetAdminDataResponse
	{
		public decimal VAT { get; private set; }
		public decimal DefaultPedalPriceMargin { get; private set; }

		public GetAdminDataResponse(decimal vat, decimal pricemargin)
		{
			VAT = vat;
			DefaultPedalPriceMargin = pricemargin;
		}
	}
}
