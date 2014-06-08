using SAMStock.DAL.Base;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigHandler : RequestHandler<GetConfigRequest, GetConfigResponse>
	{
		public GetConfigHandler(IRequestExecutor<GetConfigRequest, GetConfigResponse> executor) : base(executor)
		{
		}
	}
}
