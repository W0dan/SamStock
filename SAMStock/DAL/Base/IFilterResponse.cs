using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.BO;
using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IFilterResponse<out TBO>: IResponse where TBO: IBO
	{
		IEnumerable<TBO> Items { get; } 
	}
}
