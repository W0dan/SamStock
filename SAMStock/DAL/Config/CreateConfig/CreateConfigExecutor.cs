using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock.DAL.Config.CreateConfig
{
	public class CreateConfigExecutor: CommandExecutor<CreateConfigCommand>
	{
		public CreateConfigExecutor(IContext context) : base(context)
		{
		}

		public override int Execute(CreateConfigCommand cmd)
		{
			Context.Config.Truncate();
			var config = new Database.Config
			{
				VAT = cmd.VAT,
				DefaultPedalProfitMargin = cmd.DefaultPedalProfitMargin
			};
			Context.Config.Add(config);
			Context.SaveChanges();
			return config.Id;
		}
	}
}
