using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Admin.SetAdminData
{
	public interface ISetAdminDataCommandExecutor : IQuery
	{
		void Execute(SetAdminDataCommand cmd);
	}
}
