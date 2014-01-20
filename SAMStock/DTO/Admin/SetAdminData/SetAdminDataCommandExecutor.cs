using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Admin.SetAdminData
{
	public class SetAdminDataCommandExecutor : ISetAdminDataCommandExecutor
	{
		private readonly IContext _context;

		public SetAdminDataCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(SetAdminDataCommand cmd)
		{
			var data = _context.AdminData.Single();
			if (cmd.VAT.HasValue) data.VAT = cmd.VAT.Value;
			if (cmd.DefaultPedalPriceMargin.HasValue) data.DefaultPedalPriceMargin = cmd.DefaultPedalPriceMargin.Value;
		}
	}
}
