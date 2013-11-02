using System;
using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.Stock.AddComponent;

namespace Tests.Concerning_Stock.AddComponent.Given_an_AddComponentQueryExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private AddComponentCommand _command;
        private AddComponentCommandExecutor _sut;

        public override void Arrange()
        {
            var leverancier = new Supplier { Name = "myLeverancier" };
            Context.Supplier.AddObject(leverancier);
            Context.SaveChanges();

            _command = new AddComponentCommand("nieuwe component", 5, 10, "stocknr", 15.12M, leverancier.Id, "opmerkingen","thecode");

            _sut = new AddComponentCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_command);
        }

        [Test]
        public void It_should_create_a_new_Component()
        {
            var component = Context.Component.ToList()
                .Single(x => x.Name == "nieuwe component");

            Assert.AreEqual(_command.Name, component.Name);
            Assert.AreEqual(_command.MinimumStock, component.MinimumStock);
            Assert.AreEqual(_command.Quantity, component.Stock);
            Assert.AreEqual(_command.Stocknr, component.Stocknr);
            Assert.AreEqual(_command.Price, component.Price);
            Assert.AreEqual(_command.SupplierId, component.SupplierId);
            Assert.AreEqual(_command.Remarks, component.Remarks);
        }
    }
}