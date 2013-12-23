using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.PedalComponent.DeletePedalComponent
{
	public interface IDeletePedalComponentCommandHandler: ICommandHandler<DeletePedalComponentCommand>
	{
		new void Handle(DeletePedalComponentCommand cmd);
	}
}
