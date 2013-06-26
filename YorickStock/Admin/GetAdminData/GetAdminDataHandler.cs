using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamStock.Admin.GetAdminData
{
	public class GetAdminDataHandler : IGetAdminDataHandler
	{
		private IGetAdminDataQueryExecutor _queryexecutor;

		public GetAdminDataHandler(IGetAdminDataQueryExecutor queryexecutor)
		{
			_queryexecutor = queryexecutor;
		}

		public GetAdminDataResponse Handle(GetAdminDataRequest request)
		{
			return _queryexecutor.Execute(request);
		}
	}
}
