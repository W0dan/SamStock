using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL
{
	public abstract class RequestHandler<TRequest, TResponse>: IRequestHandler<TRequest, TResponse>
	{
		protected readonly IRequestExecutor<TRequest, TResponse> Executor;

		protected RequestHandler(IRequestExecutor<TRequest, TResponse> executor)
		{
			Executor = executor;
		}

		public TResponse Handle(TRequest req)
		{
			return Executor.Execute(req);
		}
	}
}
