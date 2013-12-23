using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Pedal.AddPedal
{
	public interface IAddPedalCommandHandler : ICommandHandler<AddPedalCommand>
	{
		new void Handle(AddPedalCommand cmd);
	}
}