using System;
using SAMStock.Business.Foundation;
using SAMStock.Business.Managers;
using SAMStock.Castle;

namespace SAMStock.Business.Objects
{
	public class Config: IBusinessObject
	{
		public decimal DefaultPedalPriceMargin { get; private set; }
		public decimal VAT { get; private set; }
		public event EventHandler<Config> Updated = delegate { };

		internal Config(Database.Config cfg)
		{
			DefaultPedalPriceMargin = cfg.DefaultPedalProfitMargin;
			VAT = cfg.VAT;

			Configs.Events.RegisterUpdate((x, y) => Updated(x, y.BO));
		}
	}
}
