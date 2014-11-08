using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigRequest: Request<GetConfigResponse>
	{
		public GetConfigRequest(object s) : base(s)
		{
		}
	}
}
