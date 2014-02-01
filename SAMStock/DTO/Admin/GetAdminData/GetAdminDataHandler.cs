namespace SAMStock.DTO.Admin.GetAdminData
{
	public class GetAdminDataHandler : RequestHandler<GetAdminDataRequest, GetAdminDataResponse>
	{
		public GetAdminDataHandler(IRequestExecutor<GetAdminDataRequest, GetAdminDataResponse> queryexecutor): base(queryexecutor)
		{
		}
	}
}
