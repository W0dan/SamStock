using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Admin.SetAdminData
{
	public class SetAdminDataCommand
	{
		public Dictionary<String, Decimal> Values;

		public SetAdminDataCommand()
		{
			Values = new Dictionary<String, Decimal>();
		}

		public SetAdminDataCommand(Dictionary<String, Decimal> list)
		{
			Values = list;
		}
	}
}
