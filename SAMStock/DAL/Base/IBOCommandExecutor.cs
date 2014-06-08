using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IBOCommandExecutor<in TCOmmand, out TBO> where TCOmmand: IBOCommand<TBO> where TBO: IBO
	{
		TBO Execute(TCOmmand cmd);
	}
}
