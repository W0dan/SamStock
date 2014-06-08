using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
