using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SamStock.Database;
using System.Globalization;

namespace SamStock.Admin.GetAdminData
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
			decimal vat = _context.AdminData.Where(x => x.Name == "VAT").Single().Value;
			decimal pricemargin = _context.AdminData.Where(x => x.Name == "DefaultPedalPriceMargin").Single().Value;
			return new GetAdminDataResponse(vat, pricemargin);
		}
	}
}
