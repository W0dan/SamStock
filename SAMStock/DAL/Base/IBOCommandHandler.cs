using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Base
{
	interface IBOCommandHandler<in TCommand, out TBO> where TCommand: IBOCommand<TBO> where TBO: BO.IBO
	{
		TBO Handle(TCommand cmd);
	}
}
