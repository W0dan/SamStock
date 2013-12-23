using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.UpdatePedalComponent
{
	public class UpdatePedalComponentCommandHandler: IUpdatePedalComponentCommandHandler
	{
		private readonly IUpdatePedalComponentCommandExecutor _executor;

		public UpdatePedalComponentCommandHandler(IUpdatePedalComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(UpdatePedalComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
