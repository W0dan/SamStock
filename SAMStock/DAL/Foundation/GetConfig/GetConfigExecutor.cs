using System;
using System.Linq;
using SAMStock.DAL.Foundation;
using SAMStock.Database;

namespace SAMStock.DAL.Config.GetConfig
{
	public class GetConfigExecutor : Executor<GetConfigRequest, GetConfigResponse>
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
			catch (InvalidOperationException ex)
			{
				throw new InvalidOperationException("Configuration has not been set yet.", ex);
			}
		}
	}
}
