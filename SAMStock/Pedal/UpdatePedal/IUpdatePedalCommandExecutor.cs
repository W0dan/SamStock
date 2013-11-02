using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.UpdatePedal
{
	public interface IUpdatePedalCommandExecutor : ICommandExecutor
	{
		void Execute(UpdatePedalCommand cmd);
	}
}
