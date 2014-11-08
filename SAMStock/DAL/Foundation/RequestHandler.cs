using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Foundation
{
	public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest: IRequest<TResponse> where TResponse: IResponse
	{
		protected readonly IRequestExecutor<TRequest, TResponse> Executor;

		protected RequestHandler(IRequestExecutor<TRequest, TResponse> executor)
		{
			Executor = executor;
		}

		public virtual TResponse Handle(TRequest req)
		{
			return Executor.Execute(req);
		}
	}
}
