using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Pedal.UpdatePedalComponents
{
	public class UpdatePedalComponentsHandler : IUpdatePedalComponentsHandler
	{
		private IUpdatePedalComponentsCommandExecutor _cmdexecutor;

		public UpdatePedalComponentsHandler(IUpdatePedalComponentsCommandExecutor cmdexecutor)
		{
			_cmdexecutor = cmdexecutor;
		}

		public void Handle(UpdatePedalComponentsCommand cmd)
		{
			_cmdexecutor.Execute(cmd);
		}
	}
}
