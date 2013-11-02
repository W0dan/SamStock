using NUnit.Framework;
using SAMStock.Supplier.GetSuppliers;
using Moq;

namespace Tests.Concerning_Suppliers.GetSuppliers.Given_a_GetLeveranciersHandler
{
    [TestFixture]
    public class When_Handle_is_called : BaseTest
    {
        private IGetSuppliersHandler _sut;
        private GetSuppliersRequest _request;
        private GetSuppliersResponse _result;
        private Mock<IGetSuppliersQueryExecutor> _queryExecutorMock;
        private GetSuppliersResponse _expectedResponse;

        public override void Arrange()
        {
            _request=new GetSuppliersRequest();
            _queryExecutorMock = new Mock<IGetSuppliersQueryExecutor>();
            _expectedResponse = new GetSuppliersResponse();
            _queryExecutorMock
                .Setup(x => x.Execute(It.IsAny<GetSuppliersRequest>()))
                .Returns(_expectedResponse);

            _sut = new GetSuppliersHandler(_queryExecutorMock.Object);
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