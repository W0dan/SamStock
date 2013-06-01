using System.Linq;
using SamStock.Stock.FilterStock;
using SamStock.Database;
using NUnit.Framework;

namespace Tests.Concerning_Stock.FilterStock.Given_a_FilterStockQueryExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private FilterStockQueryExecutor _sut;
        private FilterStockRequest _request;
        private FilterStockResponse _result;

        public override void Arrange()
        {
            _request = new FilterStockRequest("", -1, true);

            var leverancier = new Leverancier
            {
                Naam = "Musikding",
                Site = "www.musikding.de"
            };
            Context.Leverancier.AddObject(leverancier);
            Context.SaveChanges();

            var component1 = new Component
            {
                Naam = "Weerstand 180 Ohm klein",
                Stocknr = "R180E1",
                Prijs = 0.04M,
                Hoeveelheid = 10,
                MinimumStock = 5,
                Opmerkingen = "blah",
                LeverancierId = leverancier.Id
            };
            Context.Component.AddObject(component1);

            var component2 = new Component
            {
                Naam = "Weerstand 180 Ohm groot",
                Stocknr = "R180E2",
                Prijs = 0.05M,
                Hoeveelheid = 10,
                MinimumStock = 10,
                Opmerkingen = "blahblah",
                LeverancierId = leverancier.Id
            };
            Context.Component.AddObject(component2);

            var component3 = new Component
            {
                Naam = "Weerstand 180 Ohm groot",
                Stocknr = "R180E3",
                Prijs = 0.05M,
                Hoeveelheid = 10,
                MinimumStock = 15,
                Opmerkingen = "blahblah",
                LeverancierId = leverancier.Id
            };
            Context.Component.AddObject(component3);

            var component4 = new Component
            {
                Naam = "Weerstand 180 Ohm groot",
                Stocknr = "R180E4",
                Prijs = 0.05M,
                Hoeveelheid = 10,
                MinimumStock = 20,
                Opmerkingen = "blahblah",
                LeverancierId = leverancier.Id
            };
            Context.Component.AddObject(component4);
            Context.SaveChanges();

            _sut = new FilterStockQueryExecutor(Context);
        }

        public override void Act()
        {
            _result = _sut.Execute(_request);
        }

        [Test]
        public void It_should_return_2_items()
        {
            Assert.AreEqual(2, _result.List.Count);
        }

        [Test]
        public void It_should_return_an_item_with_Stocknr_R180E3()
        {
            Assert.IsTrue(_result.List.Any(x => x.Stocknr == "R180E3"));
        }

        [Test]
        public void It_should_return_an_item_with_Stocknr_R180E4()
        {
            Assert.IsTrue(_result.List.Any(x => x.Stocknr == "R180E4"));
        }
    }
}