using NUnit.Framework;
using SamStock.Beheer.Leveranciers.GetLeveranciers;

namespace Tests.Concerning_Leveranciers.GetLeveranciers.Given_a_GetLeveranciersHandler
{
    public class When_Handle_is_called:BaseTest
    {
        private IGetLeveranciersHandler _sut;
        private GetLeveranciersRequest _request;
        private GetLeveranciersResponse _result;

        public override void Arrange()
        {
            _request=new GetLeveranciersRequest();
        }

        public override void Act()
        {
            _result = _sut.Handle(_request);
        }

        [Test]
        public void It_should_return_the_result_of_the_query()
        {
            
        }
    }
}