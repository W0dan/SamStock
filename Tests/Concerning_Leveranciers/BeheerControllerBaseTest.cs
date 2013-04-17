using Castle.Windsor;
using Moq;
using SamStock.Database;
using SamStock.Utilities;
using SamStock.Web.Controllers;

namespace Tests.Concerning_Leveranciers
{
    public abstract class BeheerControllerBaseTest : BaseTest
    {
        protected BeheerController Sut;
        protected Mock<IWindsorContainer> Container;

        protected BeheerControllerBaseTest()
        {
            Container = new Mock<IWindsorContainer>();
            Container
                .Setup(x => x.Resolve<IContext>())
                .Returns(new Mock<IContext>().Object);

            var dispatcher = new Dispatcher(Container.Object);
            Sut = new BeheerController(dispatcher);
        }

    }
}