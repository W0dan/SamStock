using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Web.Controllers;
using Moq;
using Castle.Windsor;
using SamStock.Database;
using SamStock.Utilities;

namespace Tests.Concerning_Pedal {
    public abstract class PedalControllerBaseTest : BaseTest
    {
        protected PedalController Sut;
        protected Mock<IWindsorContainer> Container;

        protected PedalControllerBaseTest()
        {
            Container = new Mock<IWindsorContainer>();
            Container
                .Setup(x => x.Resolve<IContext>())
                .Returns(new Mock<IContext>().Object);

            var dispatcher = new Dispatcher(Container.Object);
            Sut = new PedalController(dispatcher);
        }
    }
}