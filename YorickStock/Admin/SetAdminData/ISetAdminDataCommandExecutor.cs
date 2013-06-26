using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Admin.SetAdminData
{
	public interface ISetAdminDataCommandExecutor : IQuery
	{
		void Execute(SetAdminDataCommand cmd);
	}
}
