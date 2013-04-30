using NUnit.Framework;
using SamStock.Beheer.Leveranciers.GetLeveranciers;
using Moq;

namespace Tests.Concerning_Leveranciers.GetLeveranciers.Given_a_GetLeveranciersHandler
{
    public class When_Handle_is_called:BaseTest
    {
        private IGetLeveranciersHandler _sut;
        private GetLeveranciersRequest _request;
        private GetLeveranciersResponse _result;
        private Mock<IGetLeveranciersQueryExecutor> _queryExecutorMock;
        private GetLeveranciersResponse _expectedResponse;

        public override void Arrange()
        {
            _request=new GetLeveranciersRequest();
            _queryExecutorMock = new Mock<IGetLeveranciersQueryExecutor>();
            _expectedResponse = new GetLeveranciersResponse();
            _queryExecutorMock
                .Setup(x => x.Execute(It.IsAny<GetLeveranciersRequest>()))
                .Returns(_expectedResponse);

            _sut = new GetLeveranciersHandler(_queryExecutorMock.Object);
        }

        public override void Act()
        {
            _result = _sut.Handle(_request);
        }

        [Test]
        public void It_should_Execute_the_GetStockOverzichtQuery()
        {
            _queryExecutorMock.Verify(x => x.Execute(_request));
        }

        [Test]
        public void It_should_return_the_result_of_the_query()
        {
            Assert.AreSame(_expectedResponse, _result);
        }
    }
}