using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Admin.GetAdminData
{
	public interface IGetAdminDataQueryExecutor : IQuery
	{
		GetAdminDataResponse Execute(GetAdminDataRequest request);
	}
}
