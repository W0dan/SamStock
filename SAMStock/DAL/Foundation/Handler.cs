using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Foundation
{
	public abstract class Handler<TRequest, TResponse> : IHandler<TRequest, TResponse> where TRequest: IRequest<TResponse> where TResponse: IResponse
	{
		protected readonly IExecutor<TRequest, TResponse> Executor;

		protected Handler(IExecutor<TRequest, TResponse> executor)
		{
			Executor = executor;
		}

		public virtual TResponse Handle(TRequest req)
		{
			return Executor.Execute(req);
		}
	}
}
