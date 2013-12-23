using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Utilities;

namespace SAMStock.Admin.GetAdminData
{
	public interface IGetAdminDataHandler : IQueryHandler<GetAdminDataRequest, GetAdminDataResponse>
	{
		new GetAdminDataResponse Handle(GetAdminDataRequest request);
	}
}