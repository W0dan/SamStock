using System.Linq;
using SAMStock.Stock.FilterStock;
using SAMStock.Database;
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

            var leverancier = new Supplier
            {
                Name = "Musikding",
                Website = "www.musikding.de"
            };
            Context.Supplier.AddObject(leverancier);
            Context.SaveChanges();

            var component1 = new Component
            {
                Name = "Weerstand 180 Ohm klein",
                Stocknr = "R180E1",
                Price = 0.04M,
                Stock = 10,
                MinimumStock = 5,
                Remarks = "blah",
                SupplierId = leverancier.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(component1);

            var component2 = new Component
            {
                Name = "Weerstand 180 Ohm groot",
                Stocknr = "R180E2",
                Price = 0.05M,
                Stock = 10,
                MinimumStock = 10,
                Remarks = "blahblah",
				SupplierId = leverancier.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(component2);

            var component3 = new Component
            {
                Name = "Weerstand 180 Ohm groot",
                Stocknr = "R180E3",
                Price = 0.05M,
                Stock = 10,
                MinimumStock = 15,
                Remarks = "blahblah",
				SupplierId = leverancier.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(component3);

            var component4 = new Component
            {
                Name = "Weerstand 180 Ohm groot",
                Stocknr = "R180E4",
                Price = 0.05M,
                Stock = 10,
                MinimumStock = 20,
                Remarks = "blahblah",
				SupplierId = leverancier.Id,
				ItemCode = "abc1235"
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
            Assert.AreEqual(2, _result.Components.Count);
        }

        [Test]
        public void It_should_return_an_item_with_Stocknr_R180E3()
        {
            Assert.IsTrue(_result.Components.Any(x => x.Stocknr == "R180E3"));
        }

        [Test]
        public void It_should_return_an_item_with_Stocknr_R180E4()
        {
            Assert.IsTrue(_result.Components.Any(x => x.Stocknr == "R180E4"));
        }
    }
}