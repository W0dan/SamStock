using System;
using Castle.Windsor;
using SAMStock.Castle;
using SAMStock.Database;
using SAMStock.DTO;
using SAMStock.Utilities;

namespace SAMStock
{
    public class SAMStockDispatcher
    {
	    private static IWindsorContainer _windsorContainer;
		private static IWindsorContainer Container {
			get { return _windsorContainer ?? (_windsorContainer = WindsorContainerStore.Container); }
			set { _windsorContainer = value; }
		}

        public static TResponse DispatchRequest<TRequest, TResponse>(TRequest request)
        {
            var handler = Container.Resolve<IRequestHandler<TRequest, TResponse>>();

            if (handler == null)
                throw new ArgumentException(string.Format("No handler found for handling {0} and {1}", typeof(TRequest).Name, typeof(TResponse).Name));

            try
            {
                return handler.Handle(request);
            }
            finally
            {
				Container.Release(handler);
            }
        }

        public static void DispatchCommand<TCommand>(TCommand command)
        {
			var handler = Container.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new ArgumentException(string.Format("No handler found for handling {0}", typeof(TCommand).Name));

			var context = Container.Resolve<IContext>();
            try
            {
                using (var tran = TransactionScopeFactory.CreateTransactionScope())
                {
                    handler.Handle(command);

                    context.SaveChanges();
                    tran.Complete();
                }
            }
            finally
            {
				Container.Release(handler);
				Container.Release(context);
            }
        }

    }
}