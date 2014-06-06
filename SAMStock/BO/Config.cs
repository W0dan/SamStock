using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using SAMStock.DAL.Config.GetConfig;
using SAMStock.DAL.Config.UpdateConfig;

namespace SAMStock.BO
{
	public static class Config
	{
		private static GetConfigResponse _config = Fetch();

		// ReSharper disable once InconsistentNaming
		public static decimal VAT
		{
			get { return _config.VAT; }
			set
			{
				Dispatcher.Command(new UpdateConfigCommand
				{
					VAT = value
				});
				_config = Fetch();
			}
		}

		public static decimal DefaultPedalProfitMargin
		{
			get { return _config.DefaultPedalProfitMargin; }
			set
			{
				Dispatcher.Command(new UpdateConfigCommand
				{
					DefaultPedalProfitMargin = value
				});
				_config = Fetch();
			}
		}

		private static GetConfigResponse Fetch()
		{
			return Dispatcher.Request<GetConfigRequest, GetConfigResponse>(new GetConfigRequest());
		}
	}
}
