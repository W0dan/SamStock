using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.Admin.SetAdminData
{
	public class SetAdminDataCommandExecutor : ISetAdminDataCommandExecutor
	{
		private IContext _context;

		public SetAdminDataCommandExecutor(IContext context)
		{
			_context = context;
		}

		public void Execute(SetAdminDataCommand cmd)
		{
			_context.AdminData.Single().VAT = cmd.VAT;
			_context.AdminData.Single().DefaultPedalPriceMargin = cmd.DefaultPedalPriceMargin;
		}
	}
}
