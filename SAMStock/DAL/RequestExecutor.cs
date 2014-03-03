using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAMStock.Database;

namespace SAMStock.DAL
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