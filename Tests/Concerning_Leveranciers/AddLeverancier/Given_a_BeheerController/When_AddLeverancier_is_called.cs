using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Beheer.Leveranciers.AddLeverancier;
using SamStock.Stock.ComponentToevoegen;
using SamStock.Utilities;
using SamStock.Web.Controllers;
using SamStock.Web.Models;

namespace Tests.Concerning_Leveranciers.AddLeverancier.Given_a_BeheerController
{
    public class When_AddLeverancier_is_called : BeheerControllerBaseTest
    {
        private Mock<IAddLeverancierHandler> _handler;
        private string _address;
        private string _website;
        private LeverancierViewModelNewItem _viewModel;
        private ActionResult _result;


        public override void Arrange()
        {
            _viewModel = new LeverancierViewModelNewItem();

            _address = "nieuw leverancieradres";
            _website = "nieuwe leverancierWebsite";

            _viewModel.Name = "nieuwe leverancier";

            _handler = new Mock<IAddLeverancierHandler>();
            Container
                .Setup(x => x.Resolve<ICommandHandler<AddLeverancierCommand>>())
                .Returns(_handler.Object);
        }

        public override void Act()
        {
            _result = Sut.AddLeverancier(_viewModel);
        }

        [Test]
        public void It_should_call_Handle_on_the_AddLeverancierHandler()
        {
            _handler.Verify(h => h.Handle(It.IsAny<AddLeverancierCommand>()));
        }

        [Test]
        public void It_should_call_it_with_the_correct_Name()
        {
            _handler.Verify(h => h.Handle(It.Is<AddLeverancierCommand>(c => c.Name == _viewModel.Name)));
        }

        [Test]
        public void It_should_call_it_with_the_correct_Address()
        {
            _handler.Verify(h => h.Handle(It.Is<AddLeverancierCommand>(c => c.Address == _viewModel.Address)));
        }

        [Test]
        public void It_should_call_it_with_the_correct_Website()
        {
            _handler.Verify(h => h.Handle(It.Is<AddLeverancierCommand>(c => c.Website == _viewModel.Website)));
        }

        [Test]
        public void It_should_redirect_to_the_Index_action()
        {
            var result = (RedirectToRouteResult)_result;
            Assert.AreEqual("Suppliers", result.RouteValues["action"]);
        }
    }
}