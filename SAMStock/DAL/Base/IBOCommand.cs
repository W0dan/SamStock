using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Base
{
	public interface IBOCommand<TBO>: ICommand where TBO: BO.IBO
	{
	}
}
