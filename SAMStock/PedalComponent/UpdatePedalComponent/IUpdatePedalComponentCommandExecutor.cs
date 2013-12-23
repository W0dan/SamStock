using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.PedalComponent.UpdatePedalComponent
{
	public interface IUpdatePedalComponentCommandExecutor
	{
		void Execute(UpdatePedalComponentCommand request);
	}
}
