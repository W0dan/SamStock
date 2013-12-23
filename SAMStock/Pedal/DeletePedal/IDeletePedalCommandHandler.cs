using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.DeletePedal
{
	public interface IDeletePedalCommandHandler: ICommandHandler<DeletePedalCommand>
	{
		new void Handle(DeletePedalCommand cmd);
	}
}
