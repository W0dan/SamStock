using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Pedal.AddPedal
{
	public class AddPedalHandler : IAddPedalHandler
	{
		private IAddPedalCommandExecutor _cmdexecutor;

		public AddPedalHandler(IAddPedalCommandExecutor cmdexecutor)
		{
			_cmdexecutor = cmdexecutor;
		}

		public void Handle(AddPedalCommand cmd)
		{
			_cmdexecutor.Execute(cmd);
		}
	}
}
