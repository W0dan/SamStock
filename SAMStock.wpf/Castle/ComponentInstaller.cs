using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SAMStock.Database;
using SAMStock.Utilities;
using Cmp = Castle.MicroKernel.Registration.Component;

namespace SAMStock.wpf.Castle
{
    public class ComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Cmp.For<IContext>()
                        .UsingFactoryMethod(fm => new SAMStockEntities()),
                Cmp.For<IDispatcher>()
                        .ImplementedBy<Dispatcher>(),
                Cmp.For<IWindsorContainer>()
                        .Instance(WindsorContainerStore.Container)
                        .LifestyleSingleton(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn(typeof(IQueryHandler<,>))
                        .WithServiceAllInterfaces()
						.LifestyleSingleton(),             
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn(typeof(ICommandHandler<>))
                        .WithServiceAllInterfaces()
						.LifestyleSingleton(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn<IQuery>()
                        .WithServiceAllInterfaces()
						.LifestyleSingleton(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn<ICommandExecutor>()
						.WithServiceAllInterfaces()
						.LifestyleSingleton()
            );
        }
    }
}