using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Admin.SetAdminData
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
