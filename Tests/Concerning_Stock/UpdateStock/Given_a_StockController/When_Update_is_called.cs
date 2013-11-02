using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.UpdateStock;
using SamStock.Utilities;
using SamStock.Web.Models.Stock;

namespace Tests.Concerning_Stock.UpdateStock.Given_a_StockController
{
    [TestFixture]
    public class When_Update_is_called : StockControllerBaseTest
    {
        private StockChangesViewModel _viewModel;
        private Mock<IUpdateStockHandler> _handler;
        private ActionResult _result;

        public override void Arrange()
        {
            _viewModel = new StockChangesViewModel();
            _viewModel.StockChanges = new List<StockChange>
                {
                    new StockChange{ Stocknr = "x25", Quantity = 5} ,
                    new StockChange{ Stocknr = "a10", Quantity = -3} ,
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
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.StockUpdates.Count == 2)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_stocknr_x25()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.StockUpdates.First().Stocknr == _viewModel.StockChanges.First().Stocknr)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_stocknr_a10()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.StockUpdates.Last().Stocknr == _viewModel.StockChanges.Last().Stocknr)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_amount_5()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.StockUpdates.First().Quantity == _viewModel.StockChanges.First().Quantity)));
        }

        [Test]
        public void the_handlers_items_should_contain_an_item_with_amount_minus_3()
        {
            _handler.Verify(u => u.Handle(It.Is<UpdateStockCommand>(c => c.StockUpdates.Last().Quantity == _viewModel.StockChanges.Last().Quantity)));
        }

        [Test]
        public void It_should_redirect_to_Index()
        {
            var result = (RedirectToRouteResult)_result;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}