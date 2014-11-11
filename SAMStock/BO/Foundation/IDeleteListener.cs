using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMStock.BO.Foundation
{
	public interface IDeleteListener<TBO> where TBO: IBusinessObject
	{
		void HandleDelete(Object sender, Deleted<TBO> deleted);
	}
}
