using System;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using SAMStock.BO.Base;
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
		}

		public static TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IRequest where TResponse : IResponse
		{
			try
			{
				var handler = Container.Resolve<IRequestHandler<TRequest, TResponse>>();
				try
				{
					return handler.Handle(request);
				}
				finally
				{
					Container.Release(handler);
				}
			}
			catch (ComponentNotFoundException)
			{
				throw new ArgumentException(string.Format("No handler found for handling {0} and {1}", typeof(TRequest).Name, typeof(TResponse).Name));
			}
		}

		public static int Command<TCommand>(TCommand command) where TCommand : ICommand
		{
			var context = Container.Resolve<IContext>();
			try
			{
				var handler = Container.Resolve<ICommandHandler<TCommand>>();
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
			catch (ComponentNotFoundException)
			{
				throw new ArgumentException(string.Format("No handler found for handling {0}", typeof(TCommand).Name));
			}
		}

		public static TBO Command<TCommand, TBO>(TCommand command) where TCommand : IBOCommand<TBO> where TBO: IBO
		{
			var context = Container.Resolve<IContext>();
			try
			{
				var handler = Container.Resolve<IBOCommandHandler<TCommand, TBO>>();
				TBO r;
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
			catch (ComponentNotFoundException)
			{
				throw new ArgumentException(string.Format("No handler found for handling {0}, {1}", typeof(TCommand).Name, typeof(TBO).Name));
			}
		}
	}
}