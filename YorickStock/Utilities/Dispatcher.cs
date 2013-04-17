using System;
using Castle.Windsor;
using SamStock.Database;

namespace SamStock.Utilities
{
    public class Dispatcher : IDispatcher {
        readonly IWindsorContainer _windsorContainer;

        public Dispatcher(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        public TResponse DispatchRequest<TRequest, TResponse>(TRequest request)
        {
            var handler = _windsorContainer.Resolve<IQueryHandler<TRequest, TResponse>>();

            if (handler == null)
                throw new ArgumentException(string.Format("No handler found for handling {0} and {1}", typeof(TRequest).Name, typeof(TResponse).Name));

            try
            {
                return handler.Handle(request);
            }
            finally
            {
                _windsorContainer.Release(handler);
            }
        }

        public void DispatchCommand<TCommand>(TCommand command)
        {
            var handler = _windsorContainer.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new ArgumentException(string.Format("No handler found for handling {0}", typeof(TCommand).Name));

            var context = _windsorContainer.Resolve<IContext>();
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
                _windsorContainer.Release(handler);
                _windsorContainer.Release(context);
            }
        }

    }
}