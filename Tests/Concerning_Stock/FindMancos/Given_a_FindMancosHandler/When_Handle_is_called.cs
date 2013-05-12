using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Stock.FindMancos;
using Moq;
using NUnit.Framework;

namespace Tests.Concerning_Stock.FindMancos.Given_a_FindMancosHandler {
    public class When_Handle_is_called : BaseTest {
        private FindMancosRequest _request;
        private FindMancosHandler _sut;
        private Mock<IFindMancosQueryExecutor> _findMancosQueryExecutor;

        public override void Arrange() {
            _request = new FindMancosRequest();

            _findMancosQueryExecutor = new Mock<IFindMancosQueryExecutor>();

            _sut = new FindMancosHandler(_findMancosQueryExecutor.Object);
        }

        public override void Act() {
            _sut.Handle(_request);
        }

        [Test]
        public void It_should_call_Execute_on_the_ComponentToevoegenCommandExecutor() {
            _findMancosQueryExecutor.Verify(x => x.Execute(_request));
        }
    }
}
