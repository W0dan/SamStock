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
		private IContext _context;

		public GetAdminDataQueryExecutor(IContext context)
		{
			_context = context;
		}

		public GetAdminDataResponse Execute(GetAdminDataRequest request)
		{
			decimal vat = _context.AdminData.Single().VAT;
			decimal pricemargin = _context.AdminData.Single().DefaultPedalPriceMargin;
			return new GetAdminDataResponse(vat, pricemargin);
		}
	}
}
