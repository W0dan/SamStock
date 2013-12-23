using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.DeletePedalComponent
{
	public interface IDeletePedalComponentCommandExecutor
	{
		void Execute(DeletePedalComponentCommand cmd);
	}
}
