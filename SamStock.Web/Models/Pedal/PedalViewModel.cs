using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;
using SamStock.Admin.GetAdminData;

namespace SamStock.Web.Models.Pedal
{
	public class PedalViewModel
	{
		public List<PedalViewModelPedal> List { get; private set; }
		public decimal VAT { get; private set; }

		public PedalViewModel(FilterPedalResponse response, GetAdminDataResponse admindata)
		{
			List = new List<PedalViewModelPedal>();
			foreach (FilterPedalResponsePedal p in response.List)
			{
				List.Add(new PedalViewModelPedal(p));
			}
			VAT = admindata.VAT;
		}
	}
}