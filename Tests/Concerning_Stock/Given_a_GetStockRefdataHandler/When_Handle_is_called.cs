using Moq;
using NUnit.Framework;
using SamStock.Stock.GetStockOverzichtRefdata;

namespace Tests.Concerning_Stock.Given_a_GetStockRefdataHandler
{
    public class When_Handle_is_called : BaseTest
    {
        private Mock<IGetStockRefdataQueryExecutor> _getStockRefdataQuery;
        private GetStockRefdataRequest _request;
        private GetStockRefdataHandler _sut;
        private GetStockRefdataResponse _expectedResponse;
        private GetStockRefdataResponse _result;

        public override void Arrange()
        {
            _request = new GetStockRefdataRequest();

            _expectedResponse = new GetStockRefdataResponse();
            _getStockRefdataQuery = new Mock<IGetStockRefdataQueryExecutor>();
            _getStockRefdataQuery
                .Setup(x => x.Execute(It.IsAny<GetStockRefdataRequest>()))
                .Returns(_expectedResponse);

            _sut = new GetStockRefdataHandler(_getStockRefdataQuery.Object);
        }

        public override void Act()
        {
            _result = _sut.Handle(_request);
        }

        [Test]
        public void It_should_call_Execute_on_the_GetStockRefdataQuery()
        {
            _getStockRefdataQuery.Verify(x => x.Execute(_request));
        }

        [Test]
        public void it_should_return_the_result_of_the_GetStockRefdataQuery()
        {
            Assert.AreSame(_expectedResponse, _result);
        }
    }
}