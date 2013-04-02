using Moq;
using NUnit.Framework;
using SamStock.Stock.ComponentToevoegen;

namespace Tests.Concerning_Stock.Given_a_ComponentToevoegenHandler
{
    public class When_Handle_is_called : BaseTest
    {
        private ComponentToevoegenCommand _command;
        private ComponentToevoegenHandler _sut;
        private Mock<IComponentToevoegenCommandExecutor> _componentToevoegenCommandExecutor;

        public override void Arrange()
        {
            _command = new ComponentToevoegenCommand("nieuwe component", 5, 10, "stocknr", 15.12M, 1, "opmerkingen");

            _componentToevoegenCommandExecutor = new Mock<IComponentToevoegenCommandExecutor>();

            _sut = new ComponentToevoegenHandler(_componentToevoegenCommandExecutor.Object);
        }

        public override void Act()
        {
            _sut.Handle(_command);
        }

        [Test]
        public void It_should_call_Execute_on_the_ComponentToevoegenCommandExecutor()
        {
            _componentToevoegenCommandExecutor.Verify(x => x.Execute(_command));
        }
    }
}