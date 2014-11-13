using System;
using System.Transactions;
using Castle.MicroKernel;
using Castle.Windsor;
using SAMStock.Castle;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using SAMStock.Utilities;

namespace SAMStock
{
	public class Dispatcher
	{
		public static T Resolve<T>() where T: IResolvable
		{
			try
			{
				return IoC.Instance.Resolve<T>();
			}
			catch (ComponentNotFoundException ex)
			{
				throw new ArgumentException(String.Format("No object found for {0}.", typeof(T).Name), ex);
			}
		}

		public static TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse> where TResponse : IResponse
		{
			try
			{
				var handler = IoC.Instance.Resolve<IHandler<TRequest, TResponse>>();
				TResponse r;
				try
				{
					using (var transaction = TransactionScopeFactory.CreateTransactionScope())
					{
						r = handler.Handle(request);
						transaction.Complete();
					}
				}
				finally
				{
					IoC.Instance.Release(handler);
				}
				return r;
			}
			catch (ComponentNotFoundException ex)
			{
				throw new ArgumentException(String.Format("No handler found for handling {0}, {1}.", typeof(TRequest).Name, typeof(TResponse).Name), ex);
			}
		}
	}
}