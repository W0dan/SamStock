using System;
using System.Linq;
using NUnit.Framework;
using SamStock.Database;
using SamStock.Stock.GetStockOverzicht;

namespace Tests.Concerning_Stock.GetStockOverzicht.Given_a_GetStockOverzichtQueryExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private GetStockOverzichtQueryExecutor _sut;
        private GetStockOverzichtRequest _request;
        private GetStockOverzichtResponse _result;
        private string _expectedFoundStocknr1;
        private string _expectedFoundStocknr2;

        public override void Arrange()
        {
            _request = new GetStockOverzichtRequest();

            var leverancier = new Leverancier
            {
                Naam = "Musikding",
                Site = "www.musikding.de"
            };
            Context.Leverancier.AddObject(leverancier);

            var leverancier1 = new Leverancier
            {
                Naam = "Banzai",
                Adres = "Kerkstraat 50, 2550 Kontich"
            };
            Context.Leverancier.AddObject(leverancier1);
            Context.SaveChanges();

            _expectedFoundStocknr1 = Guid.NewGuid().ToString().Substring(0, 15);
            var component1 = new Component
            {
                Naam = "Weerstand 180 Ohm klein",
                Stocknr = _expectedFoundStocknr1,
                Prijs = 0.04M,
                Hoeveelheid = 6,
                MinimumStock = 4,
                Opmerkingen = "blah",
                LeverancierId = leverancier.Id
            };
            Context.Component.AddObject(component1);

            _expectedFoundStocknr2 = Guid.NewGuid().ToString().Substring(0, 15);
            var component2 = new Component
            {
                Naam = "Weerstand 180 Ohm groot",
                Stocknr = _expectedFoundStocknr2,
                Prijs = 0.05M,
                Hoeveelheid = 7,
                MinimumStock = 8,
                Opmerkingen = "blahblah",
                LeverancierId = leverancier.Id
            };
            Context.Component.AddObject(component2);

            var component3 = new Component
            {
                Naam = "Weerstand 180 Ohm 3",
                Stocknr = Guid.NewGuid().ToString().Substring(0, 15),
                Prijs = 0.05M,
                Hoeveelheid = 7,
                MinimumStock = 8,
                Opmerkingen = "blahblah",
                LeverancierId = leverancier1.Id
            };
            Context.Component.AddObject(component3);

            _sut = new GetStockOverzichtQueryExecutor(Context);
        }

        public override void Act()
        {
            _result = _sut.Execute(_request);
        }

        [Test]
        public void It_should_return_3_items()
        {
            Assert.AreEqual(3, _result.List.Count);
        }

        [Test]
        public void It_should_return_an_item_with_Stocknr_R180E1()
        {
            Assert.IsTrue(_result.List.Any(x => x.Stocknr == _expectedFoundStocknr1));
        }

        [Test]
        public void It_should_return_an_item_with_Stocknr_R180E2()
        {
            Assert.IsTrue(_result.List.Any(x => x.Stocknr == _expectedFoundStocknr2));
        }

        [Test]
        public void It_should_return_an_item_with_Naam_Weerstand_180_Ohm_groot()
        {
            Assert.IsTrue(_result.List.Any(x => x.Naam == "Weerstand 180 Ohm groot"));
        }

        [Test]
        public void It_should_return_an_item_with_Prijs_4c()
        {
            Assert.IsTrue(_result.List.Any(x => x.Prijs == 0.04M));
        }

        [Test]
        public void It_should_return_an_item_with_Hoeveelheid_6()
        {
            Assert.IsTrue(_result.List.Any(x => x.Hoeveelheid == 6));
        }

        [Test]
        public void It_should_return_an_item_with_MinimumStock_4()
        {
            Assert.IsTrue(_result.List.Any(x => x.MinimumStock == 4));
        }

        [Test]
        public void It_should_return_an_item_with_Opmerkingen_blah()
        {
            Assert.IsTrue(_result.List.Any(x => x.Opmerkingen == "blah"));
        }

        [Test]
        public void It_should_return_2_items_from_leverancier_Musikding()
        {
            Assert.AreEqual(2, _result.List.Count(x => x.LeverancierNaam == "Musikding"));
        }
    }
}