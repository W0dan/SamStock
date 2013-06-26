using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Admin.SetAdminData
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
			foreach (KeyValuePair<String, Decimal> pair in cmd.Values)
			{
				_context.AdminData.Where(x => x.Name == pair.Key).Single().Value = pair.Value;
			}
		}
	}
}
