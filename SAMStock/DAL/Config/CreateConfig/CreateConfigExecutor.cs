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
			BO.Config.TriggerModified();
			return config.Id;
		}
	}
}
