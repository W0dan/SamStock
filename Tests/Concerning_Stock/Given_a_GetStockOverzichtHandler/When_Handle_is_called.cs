using Moq;
using NUnit.Framework;
using SamStock.Stock.GetStockOverzicht;

namespace Tests.Concerning_Stock.Given_a_GetStockOverzichtHandler
{
    public class When_Handle_is_called : BaseTest
    {
        private GetStockOverzichtHandler _sut;
        private Mock<IGetStockOverzichtQueryExecutor> _queryExecutorMock;
        private GetStockOverzichtQuery _query;
        private GetStockOverzichtResponse _result;
        private GetStockOverzichtResponse _expectedResponse;

        public override void Arrange()
        {
            _query = new GetStockOverzichtQuery();
            _queryExecutorMock = new Mock<IGetStockOverzichtQueryExecutor>();
            _expectedResponse = new GetStockOverzichtResponse();
            _queryExecutorMock
                .Setup(x => x.Execute(It.IsAny<GetStockOverzichtQuery>()))
                .Returns(_expectedResponse);

            _sut = new GetStockOverzichtHandler(_queryExecutorMock.Object);
        }

        public override void Act()
        {
            _result = _sut.Handle(_query);
        }

        [Test]
        public void It_should_Execute_the_GetStockOverzichtQuery()
        {
            _queryExecutorMock.Verify(x => x.Execute(_query));
        }

        [Test]
        public void It_should_return_the_result_of_the_query()
        {
            Assert.AreSame(_expectedResponse, _result);
        }
    }
}