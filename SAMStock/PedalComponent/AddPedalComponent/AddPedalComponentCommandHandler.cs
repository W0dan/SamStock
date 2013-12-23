using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.AddPedalComponent
{
	public class AddPedalComponentCommandHandler: IAddPedalComponentCommandHandler
	{
		private readonly IAddPedalComponentCommandExecutor _executor;

		public AddPedalComponentCommandHandler(IAddPedalComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(AddPedalComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
