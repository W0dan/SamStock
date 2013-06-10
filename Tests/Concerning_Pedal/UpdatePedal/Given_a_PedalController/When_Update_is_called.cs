using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using SamStock.Pedal.UpdatePedal;
using SamStock.Utilities;

namespace Tests.Concerning_Pedal.UpdatePedal.Given_a_PedalController {
    [TestFixture]
    public class When_Update_is_called:PedalControllerBaseTest {
        private Mock<IUpdatePedalHandler> _handler;

        public override void Arrange() {
            _handler = new Mock<IUpdatePedalHandler>();

            Container
                .Setup(x => x.Resolve<ICommandHandler<UpdatePedalCommand>>())
                .Returns(_handler.Object);
        }

        public override void Act() {
            Sut.Update(2,"Blaster",50.0M,20.0M);
        }

        [Test]
        public void It_should_call_Handle_on_the_Handler()
        {
            _handler.Verify(x => x.Handle(It.IsAny<UpdatePedalCommand>()));
        }

        [Test]
        public void It_should_include_the_data_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<UpdatePedalCommand>(y => y.Id == 2 && y.Name == "Blaster" && y.Price == 50.0M && y.Margin == 20.0M)));
        }
    }
}
