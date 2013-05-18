using System;
using System.Linq;
using NUnit.Framework;
using SamStock.Database;
using SamStock.Stock.ComponentToevoegen;

namespace Tests.Concerning_Stock.ComponentToevoegen.Given_a_ComponentToevoegenQueryExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private ComponentToevoegenCommand _command;
        private ComponentToevoegenCommandExecutor _sut;

        public override void Arrange()
        {
            var leverancier = new Leverancier { Naam = "myLeverancier" };
            Context.Leverancier.AddObject(leverancier);
            Context.SaveChanges();

            _command = new ComponentToevoegenCommand("nieuwe component", 5, 10, "stocknr", 15.12M, leverancier.Id, "opmerkingen");

            _sut = new ComponentToevoegenCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_command);
        }

        [Test]
        public void It_should_create_a_new_Component()
        {
            var component = Context.Component.ToList()
                .Single(x => x.Naam == "nieuwe component");

            Assert.AreEqual(_command.Naam, component.Naam);
            Assert.AreEqual(_command.MinimumStock, component.MinimumStock);
            Assert.AreEqual(_command.Hoeveelheid, component.Hoeveelheid);
            Assert.AreEqual(_command.Stocknr, component.Stocknr);
            Assert.AreEqual(_command.Prijs, component.Prijs);
            Assert.AreEqual(_command.LeverancierId, component.LeverancierId);
            Assert.AreEqual(_command.Opmerkingen, component.Opmerkingen);
        }
    }
}