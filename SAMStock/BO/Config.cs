using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using SAMStock.BO.Base;
using SAMStock.DAL.Base;
using SAMStock.DAL.Config.CreateConfig;
using SAMStock.DAL.Config.GetConfig;
using SAMStock.DAL.Config.UpdateConfig;

namespace SAMStock.BO
{
	public abstract class Config
	{
		private static GetConfigResponse _config = Fetch();
		public static event EventHandler Modified;

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
			try
			{
				return Dispatcher.Request<GetConfigRequest, GetConfigResponse>(new GetConfigRequest());
			}
			catch (InvalidOperationException)
			{
				Dispatcher.Command(new CreateConfigCommand(vat: 21, margin: 10));
				return Dispatcher.Request<GetConfigRequest, GetConfigResponse>(new GetConfigRequest());
			}
		}

		internal static void TriggerModified()
		{
			var handler = Modified;
			if (handler != null)
			{
				handler(null, EventArgs.Empty);
			}
		}
	}
}