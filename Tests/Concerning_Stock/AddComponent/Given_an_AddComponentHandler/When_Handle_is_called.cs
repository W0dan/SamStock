using Moq;
using NUnit.Framework;
using SamStock.Stock.AddComponent;

namespace Tests.Concerning_Stock.AddComponent.Given_an_AddComponentHandler
{
    [TestFixture]
    public class When_Handle_is_called : BaseTest
    {
        private AddComponentCommand _command;
        private AddComponentHandler _sut;
        private Mock<IAddComponentCommandExecutor> _addComponentCommandExecutor;

        public override void Arrange()
        {
            _command = new AddComponentCommand("nieuwe component", 5, 10, "stocknr", 15.12M, 1, "opmerkingen","thecode");

            _addComponentCommandExecutor = new Mock<IAddComponentCommandExecutor>();

            _sut = new AddComponentHandler(_addComponentCommandExecutor.Object);
        }

        public override void Act()
        {
            _sut.Handle(_command);
        }

        [Test]
        public void It_should_call_Execute_on_the_AddComponentCommandExecutor()
        {
            _addComponentCommandExecutor.Verify(x => x.Execute(_command));
        }
    }
}