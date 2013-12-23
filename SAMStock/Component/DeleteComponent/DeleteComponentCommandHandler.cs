using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Component.DeleteComponent
{
	public class DeleteComponentCommandHandler
	{
		private readonly IDeleteComponentCommandExecutor _executor;

		public DeleteComponentCommandHandler(IDeleteComponentCommandExecutor executor)
		{
			_executor = executor;
		}

		public void Handle(DeleteComponentCommand cmd)
		{
			_executor.Execute(cmd);
		}
	}
}
