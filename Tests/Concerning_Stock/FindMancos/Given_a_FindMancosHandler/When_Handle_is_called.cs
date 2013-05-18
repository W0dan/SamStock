using System;
using SamStock.Stock.FilterStock;
using Moq;
using NUnit.Framework;

namespace Tests.Concerning_Stock.FindMancos.Given_a_FindMancosHandler
{
    [TestFixture]
    public class When_Handle_is_called : BaseTest
    {
        private FilterStockRequest _request;
        private FilterStockHandler _sut;
        private Mock<IFilterStockQueryExecutor> _FilterStockQueryExecutor;

        public override void Arrange()
        {
            _request = new FilterStockRequest();

            _FilterStockQueryExecutor = new Mock<IFilterStockQueryExecutor>();

            _sut = new FilterStockHandler(_FilterStockQueryExecutor.Object);
        }

        public override void Act()
        {
            _sut.Handle(_request);
        }

        [Test]
        public void It_should_call_Execute_on_the_FilterStockQueryExecutor()
        {
            _FilterStockQueryExecutor.Verify(x => x.Execute(_request));
        }
    }
}
