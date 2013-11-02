using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.MicroKernel;
using System;

namespace SAMStock.Web._Util
{
    public class WindsorControllerFactory : IControllerFactory
    {
        readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return _kernel.Resolve<IController>(controllerName + "Controller");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }
    }
}