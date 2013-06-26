using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Utilities;

namespace SamStock.Admin.GetAdminData
{
	public interface IGetAdminDataHandler : IQueryHandler<GetAdminDataRequest, GetAdminDataResponse>
	{
	}
}