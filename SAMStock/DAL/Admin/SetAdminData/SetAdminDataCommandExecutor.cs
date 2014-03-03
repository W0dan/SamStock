using System.Linq;
using SAMStock.Database;

namespace SAMStock.DAL.Admin.SetAdminData
{
	public class SetAdminDataCommandExecutor : CommandExecutor<SetAdminDataCommand>
	{
		public SetAdminDataCommandExecutor(IContext context): base(context)
		{
		}

		public override void Execute(SetAdminDataCommand cmd)
		{
			var data = Context.AdminData.Single();
			if (cmd.VAT.HasValue) data.VAT = cmd.VAT.Value;
			if (cmd.DefaultPedalPriceMargin.HasValue) data.DefaultPedalPriceMargin = cmd.DefaultPedalPriceMargin.Value;
		}
	}
}
