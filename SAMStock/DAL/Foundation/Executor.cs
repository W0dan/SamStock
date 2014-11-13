using SAMStock.DAL.Foundation;
using SAMStock.Database;

namespace SAMStock.DAL.Foundation
{
	public abstract class Executor<TRequest, TResponse> : IExecutor<TRequest, TResponse> where TRequest: IRequest<TResponse> where TResponse: IResponse
	{
		protected readonly IContext Context;

		protected Executor(IContext context)
		{
			Context = context;
		}

		public abstract TResponse Execute(TRequest req);
	}
}