using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.PedalComponent.UpdatePedalComponent
{
	public interface IUpdatePedalComponentCommandHandler: ICommandHandler<UpdatePedalComponentCommand>
	{
		new void Handle(UpdatePedalComponentCommand cmd);
	}
}
