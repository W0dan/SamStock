using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.Pedal.DeletePedal
{
	public interface IDeletePedalCommandExecutor
	{
		void Execute(DeletePedalCommand cmd);
	}
}
