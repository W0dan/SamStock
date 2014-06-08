using System.Collections.Generic;
using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IFilterResponse<out TBO>: IResponse where TBO: IBO
	{
		IEnumerable<TBO> Items { get; } 
	}
}
