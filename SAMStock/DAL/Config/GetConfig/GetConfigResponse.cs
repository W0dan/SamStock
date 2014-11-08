using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigResponse: Response
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
