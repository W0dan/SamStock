using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.PedalComponent.AddPedalComponent
{
	public interface IAddPedalComponentCommandHandler: ICommandHandler<AddPedalComponentCommand>
	{
		new void Handle(AddPedalComponentCommand cmd);
	}
}
