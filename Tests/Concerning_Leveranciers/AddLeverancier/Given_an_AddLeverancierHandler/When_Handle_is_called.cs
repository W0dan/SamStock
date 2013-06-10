using System;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SamStock.Supplier.AddSupplier;

namespace Tests.Concerning_Leveranciers.AddLeverancier.Given_an_AddLeverancierHandler
{
    [TestFixture]
    public class When_Handle_is_called : BaseTest
    {
        private AddSupplierCommand _command;
        private AddSupplierHandler _sut;
        private Mock<IAddSupplierCommandExecutor> _addLeverancierCommandExecutor;

        public override void Arrange()
        {
            _command = new AddSupplierCommand("iqegyf", "straat", "www.bla.be");
            _addLeverancierCommandExecutor = new Mock<IAddSupplierCommandExecutor>();
            _sut = new AddSupplierHandler(_addLeverancierCommandExecutor.Object);
        }

        public override void Act()
        {
            _sut.Handle(_command);
        }

        [Test]
        public void It_should_call_Execute_on_the_AddLeverancierCommandExecutor()
        {
            _addLeverancierCommandExecutor.Verify(a => a.Execute(_command));
        }
    }


}