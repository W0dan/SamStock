using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMStock.Admin.GetAdminData;

namespace SAMStock.Web.Models.Admin
{
	public class AdminViewModel
	{
		public decimal VAT { get; set; }
		public decimal DefaultPedalPriceMargin { get; set; }

		public AdminViewModel()
		{
			VAT = 21.0M;
			DefaultPedalPriceMargin = 50.0M;
		}

		public AdminViewModel(GetAdminDataResponse response)
		{
			VAT = response.VAT;
			DefaultPedalPriceMargin = response.DefaultPedalPriceMargin;
		}
	}
}