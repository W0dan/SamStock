using SAMStock.DAL.Foundation;
using SAMStock.Database;

namespace SAMStock.DAL.Foundation
{
	public abstract class RequestExecutor<TRequest, TResponse> : IRequestExecutor<TRequest, TResponse> where TRequest: IRequest<TResponse> where TResponse: IResponse
	{
		protected readonly IContext Context;

		protected RequestExecutor(IContext context)
		{
			Context = context;
		}

		public abstract TResponse Execute(TRequest req);
	}
}