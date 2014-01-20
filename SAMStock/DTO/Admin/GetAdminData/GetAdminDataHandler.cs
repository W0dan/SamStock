namespace SAMStock.DTO.Admin.GetAdminData
{
	public class GetAdminDataHandler : IGetAdminDataHandler
	{
		private readonly IGetAdminDataQueryExecutor _queryexecutor;

		public GetAdminDataHandler(IGetAdminDataQueryExecutor queryexecutor)
		{
			_queryexecutor = queryexecutor;
		}

		public GetAdminDataResponse Handle(GetAdminDataRequest request)
		{
			return _queryexecutor.Execute(request);
		}
	}
}
