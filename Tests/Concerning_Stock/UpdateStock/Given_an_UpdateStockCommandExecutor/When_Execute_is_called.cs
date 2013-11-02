using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.Stock.UpdateStock;

namespace Tests.Concerning_Stock.UpdateStock.Given_an_UpdateStockCommandExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private UpdateStockCommandExecutor _sut;
        private UpdateStockCommand _command;

        public override void Arrange()
        {
            var leverancier = new Supplier
                {
                    Name = "testlev",
                };
            Context.Supplier.AddObject(leverancier);

            Context.Component.AddObject(new Component
                {
                    Stocknr = "a15",
                    Name = "weerstand",
                    Supplier = leverancier,
                    Stock = 10
                });
            Context.Component.AddObject(new Component
                {
                    Stocknr = "b15",
                    Name = "condensator",
                    Supplier = leverancier,
                    Stock = 10,
                    Price = 1
                });
            Context.Component.AddObject(new Component
                {
                    Stocknr = "c15",
                    Name = "led",
                    Supplier = leverancier,
                    Stock = 10,
                    Price = 1
                });

            _command = new UpdateStockCommand();
            _command.StockUpdates = new List<StockUpdate>();
            _command.StockUpdates.Add(new StockUpdate("b15", 10, 3M));
            _command.StockUpdates.Add(new StockUpdate("c15", -3, 0.75M));
            _sut = new UpdateStockCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_command);
        }

        [Test]
        public void It_should_contain_the_right_amount_for_comp_a15()
        {
            var component_a15 = Context.Component.Single(x => x.Stocknr == "a15");

            Assert.AreEqual(10, component_a15.Stock);
        }

        [Test]
        public void It_should_contain_the_right_amount_for_comp_b15()
        {
            var component_b15 = Context.Component.Single(x => x.Stocknr == "b15");

            Assert.AreEqual(20, component_b15.Stock);
        }

        [Test]
        public void It_should_contain_the_correct_new_price_for_comp_b15()
        {
            var component_b15 = Context.Component.Single(x => x.Stocknr == "b15");

            Assert.AreEqual(2, component_b15.Price);
        }

        [Test]
        public void It_should_contain_the_right_amount_for_comp_c15()
        {
            var component_c15 = Context.Component.Single(x => x.Stocknr == "c15");

            Assert.AreEqual(7, component_c15.Stock);
        }
    }
}