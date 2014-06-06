using System;
using System.Windows.Forms.VisualStyles;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using SAMStock.Castle;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.DAL;
using SAMStock.Utilities;

namespace SAMStock
{
	public class Dispatcher
	{
		private static IWindsorContainer _windsorContainer;

		private static IWindsorContainer Container
		{
			get { return _windsorContainer ?? (_windsorContainer = WindsorContainerStore.Container); }
			set { _windsorContainer = value; }
		}

		public static TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IRequest
			where TResponse : IResponse
		{
			var handler = Container.Resolve<IRequestHandler<TRequest, TResponse>>();

			if (handler == null)
				throw new ArgumentException(string.Format("No handler found for handling {0} and {1}", typeof (TRequest).Name,
					typeof (TResponse).Name));

			try
			{
				return handler.Handle(request);
			}
			finally
			{
				Container.Release(handler);
			}
		}

		public static int Command<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handler = Container.Resolve<ICommandHandler<TCommand>>();

			if (handler == null)
				throw new ArgumentException(string.Format("No handler found for handling {0}", typeof (TCommand).Name));

			var context = Container.Resolve<IContext>();
			int r;
			try
			{
				using (var tran = TransactionScopeFactory.CreateTransactionScope())
				{
					r = handler.Handle(command);
					tran.Complete();
				}
			}
			finally
			{
				Container.Release(handler);
				Container.Release(context);
			}
			return r;
		}
	}
}