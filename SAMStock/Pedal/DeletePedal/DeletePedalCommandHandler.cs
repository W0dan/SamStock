using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.DeletePedal
{
	public class DeletePedalCommandHandler: IDeletePedalCommandHandler
	{
		private readonly IDeletePedalCommandExecutor _executor;

		public DeletePedalCommandHandler(IDeletePedalCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeletePedalCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
