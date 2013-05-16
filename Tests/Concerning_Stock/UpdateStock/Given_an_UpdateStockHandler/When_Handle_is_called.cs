using Moq;
using NUnit.Framework;
using SamStock.Stock.UpdateStock;

namespace Tests.Concerning_Stock.UpdateStock.Given_an_UpdateStockHandler
{
    [TestFixture]
    public class When_Handle_is_called : BaseTest
    {
        private UpdateStockHandler _sut;
        private UpdateStockCommand _command;
        private Mock<IUpdateStockCommandExecutor> _commandexecutor;

        public override void Arrange()
        {
            _command = new UpdateStockCommand();
            _commandexecutor = new Mock<IUpdateStockCommandExecutor>();
            _sut = new UpdateStockHandler(_commandexecutor.Object);
        }

        public override void Act()
        {
            _sut.Handle(_command);
        }

        [Test]
        public void It_should_call_Execute_on_UpdateStockCommandExecutor()
        {
            _commandexecutor.Verify(e => e.Execute(_command));
        }
    }
}