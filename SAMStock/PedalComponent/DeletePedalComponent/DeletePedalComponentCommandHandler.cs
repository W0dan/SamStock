using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.DeletePedalComponent
{
	public class DeletePedalComponentCommandHandler: IDeletePedalComponentCommandHandler
	{
		private readonly IDeletePedalComponentCommandExecutor _executor;

		public DeletePedalComponentCommandHandler(IDeletePedalComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeletePedalComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
