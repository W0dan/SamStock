using SAMStock.Database;

namespace SAMStock.DAL.Base
{
	public abstract class RequestExecutor<TRequest, TResponse> : IRequestExecutor<TRequest, TResponse>
	{
		protected readonly IContext Context;

		protected RequestExecutor(IContext context)
		{
			Context = context;
		}

		public abstract TResponse Execute(TRequest req);
	}
}