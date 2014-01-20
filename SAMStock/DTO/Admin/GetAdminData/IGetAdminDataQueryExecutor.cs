using SAMStock.Utilities;

namespace SAMStock.DTO.Admin.GetAdminData
{
	public interface IGetAdminDataQueryExecutor : IQuery
	{
		GetAdminDataResponse Execute(GetAdminDataRequest request);
	}
}
