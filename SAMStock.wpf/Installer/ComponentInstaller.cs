using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SAMStock.Database;
using SAMStock.Utilities;
using Component = Castle.MicroKernel.Registration.Component;

namespace SAMStock.wpf.Installer
{
    public class ComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IContext>()
                        .UsingFactoryMethod(fm => new SAMStockEntities()),
                Component.For<IDispatcher>()
                        .ImplementedBy<Dispatcher>(),
                Component.For<IWindsorContainer>()
                        .Instance(IoC.Container)
                        .LifestyleSingleton(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn(typeof(IQueryHandler<,>))
                        .WithServiceAllInterfaces()
						.LifestyleTransient(),                
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn(typeof(ICommandHandler<>))
                        .WithServiceAllInterfaces()
						.LifestyleTransient(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn<IQuery>()
                        .WithServiceAllInterfaces()
						.LifestyleTransient(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn<ICommandExecutor>()
						.WithServiceAllInterfaces()
						.LifestyleTransient()
            );
        }
    }
}