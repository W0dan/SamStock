using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SAMStock.Database;
using System.Globalization;

namespace SAMStock.Admin.GetAdminData
{
	public class GetAdminDataQueryExecutor : IGetAdminDataQueryExecutor
	{
		private readonly IContext _context;

		public GetAdminDataQueryExecutor(IContext context)
		{
			_context = context;
		}

		public GetAdminDataResponse Execute(GetAdminDataRequest request)
		{
			var config = _context.AdminData.Single();
			return new GetAdminDataResponse
			{
				VAT = config.VAT,
				DefaultPedalPriceMargin = config.DefaultPedalPriceMargin
			};
		}
	}
}
