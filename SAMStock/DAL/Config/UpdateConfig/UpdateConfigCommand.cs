using SAMStock.DAL.Base;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigCommand: ICommand
	{
		public decimal? VAT { get; set; }
		public decimal? DefaultPedalProfitMargin { get; set; }
	}
}
