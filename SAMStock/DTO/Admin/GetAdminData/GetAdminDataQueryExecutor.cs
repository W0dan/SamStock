using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Admin.GetAdminData
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
