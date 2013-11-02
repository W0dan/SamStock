using Castle.Windsor;
using Moq;
using SamStock.Database;
using SamStock.Utilities;
using SamStock.Web.Controllers;

namespace Tests.Concerning_Stock
{
    public abstract class StockControllerBaseTest : BaseTest
    {
        protected StockController Sut;
        protected Mock<IWindsorContainer> Container;

        protected StockControllerBaseTest()
        {
            Container = new Mock<IWindsorContainer>();
            Container
                .Setup(x => x.Resolve<IContext>())
                .Returns(new Mock<IContext>().Object);

            var dispatcher = new Dispatcher(Container.Object);
            Sut = new StockController(dispatcher);
        }
    }
}