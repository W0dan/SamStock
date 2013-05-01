using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.UpdateStock;
using SamStock.Utilities;
using SamStock.Web.Models;

namespace Tests.Concerning_Stock.UpdateStock.Given_a_StockController
{
    public class When_Update_is_called : StockControllerBaseTest
    {
        private StockChangesViewModel _viewModel;
        private Mock<IUpdateStockHandler> _handler;
        private ActionResult _result;

        public override void Arrange()
        {
            _viewModel = new StockChangesViewModel();
            _viewModel.List = new List<StockChange>
                {
                    new StockChange{ Stocknr = "x25", Amount = 5} ,
                    new StockChange{ Stocknr = "a10", Amount = -3} ,
                };

            _handler = new Mock<IUpdateStockHandler>();

            Container
                .Setup(x => x.Resolve<ICommandHandler<UpdateStockCommand>>())
                .Returns(_handler.Object);
        }

        public override void Act()
        {
            _result = Sut.Update(_viewModel);
        }

        [Test]
        public void It_should_call_Handle_on_UpdateStockHandler()
        {
            _handler.Verify(u => u.Handle(It.IsAny<UpdateStockCommand>()));
        }

        [Test]
        public void the_Handler_should_get_two_items()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.List.Count == 2)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_stocknr_x25()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.List.First().Stocknr == _viewModel.List.First().Stocknr)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_stocknr_a10()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.List.Last().Stocknr == _viewModel.List.Last().Stocknr)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_amount_5()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.List.First().Amount == _viewModel.List.First().Amount)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_amount_minus_3()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.List.Last().Amount == _viewModel.List.Last().Amount)));
        }

        [Test]
        public void It_should_redirect_to_Index()
        {
            var result = (RedirectToRouteResult)_result;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}