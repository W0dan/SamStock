using Castle.Windsor;
using Moq;
using SamStock.Database;
using SamStock.Utilities;
using SamStock.Web.Controllers;

namespace Tests.Concerning_Suppliers
{
    public abstract class SupplierControllerBaseTest : BaseTest
    {
        protected SupplierController Sut;
        protected Mock<IWindsorContainer> Container;

        protected SupplierControllerBaseTest()
        {
            Container = new Mock<IWindsorContainer>();
            Container
                .Setup(x => x.Resolve<IContext>())
                .Returns(new Mock<IContext>().Object);

            var dispatcher = new Dispatcher(Container.Object);
            Sut = new SupplierController(dispatcher);
        }

    }
}