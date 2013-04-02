using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SamStock.Utilities;

namespace SamStock.Web._Util
{
    public class ComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Database.StockBeheerEntities>()
                        .UsingFactoryMethod(fm => new Database.StockBeheerEntities())
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