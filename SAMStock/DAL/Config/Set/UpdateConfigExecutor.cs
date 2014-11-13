using System.Linq;
using SAMStock.Castle;
using SAMStock.DAL.Config.UpdateConfig;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using Util;

namespace SAMStock.DAL.Config.Set
{
	class UpdateConfigExecutor: Executor<UpdateConfigRequest, UpdateConfigResponse>
	{
		public UpdateConfigExecutor(IContext context) : base(context)
		{
		}

		public override void Execute(UpdateConfigRequest cmd)
		{
			var config = Context.Config.Single();
			cmd.DefaultPedalProfitMargin.IfNotNull(x => config.DefaultPedalProfitMargin = x);
			cmd.VAT.IfNotNull(x => config.VAT = x);
			Context.SaveChanges();
			IoC.Instance.Resolve<Config>().TriggerModified();
		}
	}
}
