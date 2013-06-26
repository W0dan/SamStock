using System;
using Moq;
using NUnit.Framework;
using SamStock.Stock.AddComponent;
using SamStock.Utilities;
using SamStock.Web.Models.Stock;

namespace Tests.Concerning_Stock.AddComponent.Given_a_StockController
{
    [TestFixture]
    public class When_AddComponent_is_called : StockControllerBaseTest
    {
        private Mock<IAddComponentHandler> _handler;
        private StockViewModelNewItem _newItem;

        public override void Arrange()
        {

            _newItem = new StockViewModelNewItem
                {
                    Stocknr = Guid.NewGuid().ToString(),
                    Quantity = 1542,
                    SupplierId = 1242,
                    MinimumStock = 25,
                    Name = Guid.NewGuid().ToString(),
                    Remarks = Guid.NewGuid().ToString(),
                    Price = 15.36M
                };

            _handler = new Mock<IAddComponentHandler>();
            Container
                .Setup(x => x.Resolve<ICommandHandler<AddComponentCommand>>())
                .Returns(_handler.Object);
        }

        public override void Act()
        {
            Sut.AddComponent(_newItem);
        }

        [Test]
        public void It_should_call_Handle_on_the_AddComponentHandler()
        {
            _handler.Verify(x => x.Handle(It.IsAny<AddComponentCommand>()));
        }

        [Test]
        public void It_should_include_StockNr_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.Stocknr == _newItem.Stocknr)));
        }

        [Test]
        public void It_should_include_Name_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.Name == _newItem.Name)));
        }

        [Test]
        public void It_should_include_Price_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.Price == _newItem.Price)));
        }

        [Test]
        public void It_should_include_Quantity_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.Quantity == _newItem.Quantity)));
        }

        [Test]
        public void It_should_include_MinimumStock_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.MinimumStock == _newItem.MinimumStock)));
        }

        [Test]
        public void It_should_include_SupplierId_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.SupplierId == _newItem.SupplierId)));
        }

        [Test]
        public void It_should_include_Remarks_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<AddComponentCommand>(y => y.Remarks == _newItem.Remarks)));
        }
    }
}