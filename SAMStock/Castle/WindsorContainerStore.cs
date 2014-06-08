using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SAMStock.Castle
{
    internal abstract class WindsorContainerStore
    {
	    private static IWindsorContainer _container;
        public static IWindsorContainer Container {
			get
			{
				if (_container == null)
				{
					_container = new WindsorContainer();
					_container.Install(new ComponentInstaller());
				}
				return _container;
			}
	        set { _container = value; }
        }
    }
}