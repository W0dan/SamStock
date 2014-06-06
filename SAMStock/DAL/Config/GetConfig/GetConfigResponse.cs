using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigResponse: IResponse
	{
		public decimal VAT { get; private set; }
		public decimal DefaultPedalProfitMargin { get; private set; }

		public GetConfigResponse(Database.Config config)
		{
			VAT = config.VAT;
			DefaultPedalProfitMargin = config.DefaultPedalProfitMargin;
		}
	}
}
