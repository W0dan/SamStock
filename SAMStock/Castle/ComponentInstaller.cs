using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SAMStock.BO;
using SAMStock.DAL.Base;
using SAMStock.Database;
using SAMStock.DAL;
using SAMStock.Utilities;
using Cmp = Castle.MicroKernel.Registration.Component;

namespace SAMStock.Castle
{
    internal class ComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Cmp.For<IContext>()
                        .UsingFactoryMethod(fm => new SAMStockEntities()),
                Classes.FromThisAssembly()
                        .BasedOn(typeof(IRequestHandler<,>))
                        .WithServiceAllInterfaces()
						.LifestyleSingleton(),
				Classes.FromThisAssembly()
						.BasedOn(typeof(IRequestExecutor<,>))
						.WithServiceAllInterfaces()
						.LifestyleSingleton(),
				Classes.FromThisAssembly()
                        .BasedOn(typeof(ICommandHandler<>))
                        .WithServiceAllInterfaces()
						.LifestyleSingleton(),
				Classes.FromThisAssembly()
                        .BasedOn(typeof(ICommandExecutor<>))
						.WithServiceAllInterfaces()
						.LifestyleSingleton(),
						Classes.FromThisAssembly()
						.BasedOn(typeof(IBOCommandHandler<,>))
						.WithServiceAllInterfaces()
						.LifestyleSingleton(),
				Classes.FromThisAssembly()
						.BasedOn(typeof(IBOCommandExecutor<,>))
						.WithServiceAllInterfaces()
						.LifestyleSingleton()
            );
        }
    }
}