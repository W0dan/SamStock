using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Admin.SetAdminData
{
	public class SetAdminDataHandler : ISetAdminDataHandler
	{
		private ISetAdminDataCommandExecutor _cmdexecutor;

		public SetAdminDataHandler(ISetAdminDataCommandExecutor cmdexecutor)
		{
			_cmdexecutor = cmdexecutor;
		}

		public void Handle(SetAdminDataCommand cmd)
		{
			_cmdexecutor.Execute(cmd);
		}
	}
}
