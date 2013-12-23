using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Component.DeleteComponent
{
	public interface IDeleteComponentCommandHandler: ICommandHandler<DeleteComponentCommand>
	{
		new void Handle(DeleteComponentCommand cmd);
	}
}
