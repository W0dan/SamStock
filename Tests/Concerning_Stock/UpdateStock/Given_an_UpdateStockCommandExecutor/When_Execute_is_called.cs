using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SamStock.Database;
using SamStock.Stock.UpdateStock;

namespace Tests.Concerning_Stock.UpdateStock.Given_an_UpdateStockCommandExecutor
{
    public class When_Execute_is_called : DatabaseTest
    {
        private UpdateStockCommandExecutor _sut;
        private UpdateStockCommand _command;

        public override void Arrange()
        {
            var leverancier = new Leverancier
                {
                    Naam = "testlev",
                };
            Context.Leverancier.AddObject(leverancier);

            Context.Component.AddObject(new Component
                {
                    Stocknr = "a15",
                    Naam = "weerstand",
                    Leverancier = leverancier,
                    Hoeveelheid = 10
                });
            Context.Component.AddObject(new Component
                {
                    Stocknr = "b15",
                    Naam = "condensator",
                    Leverancier = leverancier,
                    Hoeveelheid = 10,
                    Prijs = 1
                });
            Context.Component.AddObject(new Component
                {
                    Stocknr = "c15",
                    Naam = "led",
                    Leverancier = leverancier,
                    Hoeveelheid = 10,
                    Prijs = 1
                });

            _command = new UpdateStockCommand();
            _command.List = new List<StockUpdate>();
            _command.List.Add(new StockUpdate("b15", 10, 3M));
            _command.List.Add(new StockUpdate("c15", -3, 0.75M));
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

            Assert.AreEqual(10, component_a15.Hoeveelheid);
        }

        [Test]
        public void It_should_contain_the_right_amount_for_comp_b15()
        {
            var component_b15 = Context.Component.Single(x => x.Stocknr == "b15");

            Assert.AreEqual(20, component_b15.Hoeveelheid);
        }

        [Test]
        public void It_should_contain_the_correct_new_price_for_comp_b15()
        {
            var component_b15 = Context.Component.Single(x => x.Stocknr == "b15");

            Assert.AreEqual(2, component_b15.Prijs);
        }

        [Test]
        public void It_should_contain_the_right_amount_for_comp_c15()
        {
            var component_c15 = Context.Component.Single(x => x.Stocknr == "c15");

            Assert.AreEqual(7, component_c15.Hoeveelheid);
        }
    }
}