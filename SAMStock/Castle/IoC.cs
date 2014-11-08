using Castle.Windsor;

namespace SAMStock.Castle
{
    internal class IoC
    {
	    private static IWindsorContainer _container;
	    public static IWindsorContainer Instance
	    {
		    get
		    {
			    if (ReferenceEquals(null, _container))
			    {
				    _container = new WindsorContainer();
				    _container.Install(new ComponentInstaller());
			    }
			    return _container;
		    }
	    }
    }
}