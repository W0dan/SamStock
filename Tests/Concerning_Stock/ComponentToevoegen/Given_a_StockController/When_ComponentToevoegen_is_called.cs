using System;
using Moq;
using NUnit.Framework;
using SamStock.Stock.ComponentToevoegen;
using SamStock.Utilities;
using SamStock.Web.Models;

namespace Tests.Concerning_Stock.ComponentToevoegen.Given_a_StockController
{
    public class When_ComponentToevoegen_is_called : StockControllerBaseTest
    {
        private StockViewModel _model;
        private Mock<IComponentToevoegenHandler> _handler;

        public override void Arrange()
        {
            _model = new StockViewModel
                {
                    NewItem = new StockViewModelNewItem
                        {
                            Stocknr = Guid.NewGuid().ToString(),
                            Hoeveelheid = 1542,
                            LeverancierId = 1242,
                            MinimumStock = 25,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 15.36M
                        }
                };

            _handler = new Mock<IComponentToevoegenHandler>();
            Container
                .Setup(x => x.Resolve<ICommandHandler<ComponentToevoegenCommand>>())
                .Returns(_handler.Object);
        }

        public override void Act()
        {
            Sut.ComponentToevoegen(_model);
        }

        [Test]
        public void It_should_call_Handle_on_the_ComponentToevoegenHandler()
        {
            _handler.Verify(x => x.Handle(It.IsAny<ComponentToevoegenCommand>()));
        }

        [Test]
        public void It_should_include_StockNr_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.Stocknr == _model.NewItem.Stocknr)));
        }

        [Test]
        public void It_should_include_Naam_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.Naam == _model.NewItem.Naam)));
        }

        [Test]
        public void It_should_include_Prijs_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.Prijs == _model.NewItem.Prijs)));
        }

        [Test]
        public void It_should_include_Hoeveelheid_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.Hoeveelheid == _model.NewItem.Hoeveelheid)));
        }

        [Test]
        public void It_should_include_MinimumStock_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.MinimumStock == _model.NewItem.MinimumStock)));
        }

        [Test]
        public void It_should_include_LeverancierId_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.LeverancierId == _model.NewItem.LeverancierId)));
        }

        [Test]
        public void It_should_include_Opmerkingen_in_the_call()
        {
            _handler.Verify(x => x.Handle(It.Is<ComponentToevoegenCommand>(y => y.Opmerkingen == _model.NewItem.Opmerkingen)));
        }
    }
}