using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			return config.Id;
		}
	}
}
