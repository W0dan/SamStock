using SAMStock.Utilities;

namespace SAMStock.DTO.Admin.GetAdminData
{
	public interface IGetAdminDataHandler : IQueryHandler<GetAdminDataRequest, GetAdminDataResponse>
	{
		new GetAdminDataResponse Handle(GetAdminDataRequest request);
	}
}