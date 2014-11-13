using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigRequest: Request<UpdateConfigResponse>
	{
		public UpdateConfigRequest(object s) : base(s)
		{
		}

		public decimal? VAT { get; set; }
		public decimal? DefaultPedalProfitMargin { get; set; }
	}
}
