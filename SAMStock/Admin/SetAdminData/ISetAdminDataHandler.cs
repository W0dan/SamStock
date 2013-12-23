using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Admin.SetAdminData
{
	public interface ISetAdminDataHandler : ICommandHandler<SetAdminDataCommand>
	{
		new void Handle(SetAdminDataCommand command);
	}
}
