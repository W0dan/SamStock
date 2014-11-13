using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigHandler : Handler<GetConfigRequest, GetConfigResponse>
	{
		public GetConfigHandler(IExecutor<GetConfigRequest, GetConfigResponse> executor) : base(executor)
		{
		}
	}
}
