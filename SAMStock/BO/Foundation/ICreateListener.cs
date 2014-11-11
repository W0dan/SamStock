using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMStock.BO.Foundation
{
	public interface ICreateListener<TBO> where TBO: IBusinessObject
	{
		void HandleCreate(Object Sender, Created<TBO> created);
	}
}
