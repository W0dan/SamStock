using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SAMStock.Business.Foundation;
using SAMStock.DAL.Foundation;
using SAMStock.Database;
using Cmp = Castle.MicroKernel.Registration.Component;

namespace SAMStock.Castle
{
	internal class ComponentInstaller : IWindsorInstaller
    {
	    public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Cmp.For<IContext>()
					.UsingFactoryMethod(x => new SAMStockEntities())
					.LifestyleTransient(),
                Classes.FromThisAssembly()
					.BasedOn(typeof(IHandler<,>))
					.LifestyleTransient()
					.WithServiceAllInterfaces(),
				Classes.FromThisAssembly()
					.BasedOn(typeof(IExecutor<,>))
					.LifestyleTransient()
					.WithServiceAllInterfaces(),
				Classes.FromThisAssembly()
					.BasedOn(typeof(IManager<>))
					.LifestyleTransient()
					.WithServiceAllInterfaces(),
				Classes.FromThisAssembly()
					.BasedOn(typeof(Manager<>))
					.LifestyleTransient()
					.WithServiceAllInterfaces()
            );
        }
    }
}