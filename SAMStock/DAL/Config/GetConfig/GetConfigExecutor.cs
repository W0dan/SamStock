using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.DAL.Base;
using SAMStock.Database;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigExecutor : RequestExecutor<GetConfigRequest, GetConfigResponse>
	{
		public GetConfigExecutor(IContext context) : base(context)
		{
		}

		public override GetConfigResponse Execute(GetConfigRequest req)
		{
			try
			{
				return new GetConfigResponse(Context.Config.Single());
			}
			catch (InvalidOperationException)
			{
				throw new InvalidOperationException("Configuration has not been set yet.");
			}
		}
	}
}
