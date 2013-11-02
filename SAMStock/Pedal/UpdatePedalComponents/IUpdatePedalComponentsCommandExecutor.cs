using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.UpdatePedalComponents
{
	public interface IUpdatePedalComponentsCommandExecutor : ICommandExecutor
	{
		void Execute(UpdatePedalComponentsCommand cmd);
	}
}
