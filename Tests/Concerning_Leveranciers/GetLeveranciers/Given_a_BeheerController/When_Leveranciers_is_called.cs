using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Beheer.Leveranciers.GetLeveranciers;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Utilities;
using SamStock.Web.Controllers;
using SamStock.Web.Models;
using Tests._Util;

namespace Tests.Concerning_Leveranciers.GetLeveranciers.Given_a_BeheerController
{
    public class When_Leveranciers_is_called : BeheerControllerBaseTest
    {
        private GetLeveranciersResponse _response;
        private ViewResult _result;
        private LeveranciersViewModel _viewModel;
        private Mock<IGetLeveranciersHandler> _getLeveranciersHandler;

        public override void Arrange()
        {
            _response = new GetLeveranciersResponse();

            _response.List = new List<GetLeveranciersItem>();

            _response.List.Add(new GetLeveranciersItem("dummy naam", "dummy adres", "dummy website"));
            _response.List.Add(new GetLeveranciersItem("dummy naam1", "dummy adres1", "dummy website2"));

            _getLeveranciersHandler = new Mock<IGetLeveranciersHandler>();
            _getLeveranciersHandler
                .Setup(x => x.Handle(It.IsAny<GetLeveranciersRequest>()))
                .Returns(_response);

            Container
                .Setup(x => x.Resolve<IQueryHandler<GetLeveranciersRequest, GetLeveranciersResponse>>())
                .Returns(_getLeveranciersHandler.Object);
        }

        public override void Act()
        {
            _result = Sut.Suppliers();
            _viewModel = (LeveranciersViewModel)_result.Model;
        }

        [Test]
        public void It_should_put_the_leveranciers_in_the_viewmodel()
        {
            _viewModel.List.ShouldMatchAllItemsOf(_response.List, (x, y) => x.Adres == y.Adres);
        }
    }
}