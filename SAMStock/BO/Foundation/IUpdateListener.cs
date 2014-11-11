using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMStock.BO.Foundation
{
	public interface IUpdateListener<TBO> where TBO: IBusinessObject
	{
		void HandleUpdate(Object sender, Updated<TBO> updated);
	}
}
