﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SamStock.Web._Util;

namespace SamStock.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BootstrapWindsorContainer();
        }

        private static void BootstrapWindsorContainer()
        {
            var container = new WindsorContainer();
            var controllerFactory = new WindsorControllerFactory(container.Kernel); // Create a new instance
            ControllerBuilder.Current.SetControllerFactory(controllerFactory); // Use my factory instead of default

            IoC.Container = container;
            container.Install(FromAssembly.This());
        }
    }
}