using System.Linq;
using SAMStock.Database;

namespace SAMStock.DTO.Admin.GetAdminData
{
	public class GetAdminDataRequestExecutor : RequestExecutor<GetAdminDataRequest, GetAdminDataResponse>
	{
		public GetAdminDataRequestExecutor(IContext context): base(context)
		{
		}

		public override GetAdminDataResponse Execute(GetAdminDataRequest request)
		{
			var config = Context.AdminData.Single();
			return new GetAdminDataResponse
			{
				VAT = config.VAT,
				DefaultPedalPriceMargin = config.DefaultPedalPriceMargin
			};
		}
	}
}
