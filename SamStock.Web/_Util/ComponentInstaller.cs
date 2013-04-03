using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SamStock.Database;
using SamStock.Utilities;
using Component = Castle.MicroKernel.Registration.Component;

namespace SamStock.Web._Util
{
    public class ComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IContext>()
                        .UsingFactoryMethod(fm => new StockBeheerEntities())
                        .LifestylePerWebRequest(),
                Classes.FromThisAssembly()
                       .BasedOn<IController>()
                       .WithService.AllInterfaces()
                       .Configure(c => c.Named(c.Implementation.Name))
                       .LifestylePerWebRequest(),
                Component.For<IDispatcher>()
                        .ImplementedBy<Dispatcher>(),
                Component.For<IWindsorContainer>()
                        .Instance(IoC.Container)
                        .LifestyleSingleton(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn(typeof(IQueryHandler<,>))
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest(),                
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn(typeof(ICommandHandler<>))
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn<IQuery>()
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest(),
                Classes.FromAssemblyContaining<Dispatcher>()
                        .BasedOn<ICommandExecutor>()
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest()
            );

        }
    }
}