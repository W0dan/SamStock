using System.Linq;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Config.UpdateConfig
{
	public class UpdateConfigExecutor: CommandExecutor<UpdateConfigCommand>
	{
		public UpdateConfigExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(UpdateConfigCommand cmd)
		{
			var config = Context.Config.Single();
			cmd.DefaultPedalProfitMargin.IfNotNull(x => config.DefaultPedalProfitMargin = x);
			cmd.VAT.IfNotNull(x => config.VAT = x);
			Context.SaveChanges();
			BO.Config.TriggerModified();
			return config.Id;
		}
	}
}
