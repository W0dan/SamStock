using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SAMStock.PedalComponent.AddPedalComponent
{
	public interface IAddPedalComponentCommandExecutor
	{
		void Execute(AddPedalComponentCommand cmd);
	}
}
