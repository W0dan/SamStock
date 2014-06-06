using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DAL.Component.AddComponent;

namespace Tests.Components.AddComponent.AddComponentQueryExecutor
{
    [TestFixture]
    public class WhenExecuteIsCalled : DatabaseTest
    {
        private AddComponentCommand _cmd;
        private AddComponentCommandExecutor _sut;

        public override void Arrange()
        {
            var s = new Supplier
            {
	            Name = "Jack"
            };
            Context.Supplier.AddObject(s);
            Context.SaveChanges();

            _cmd = new AddComponentCommand
            {
	            ItemCode = "abc1234",
				MinimumStock = 5,
				Name = "Comp",
				Price = 20,
				Quantity = 10,
				Remarks = "",
				Stocknr = "125",
				SupplierId = Context.Supplier.Single().Id
            };
            _sut = new AddComponentCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_cmd);
        }

        [Test]
        public void It_should_store_the_Component()
        {
	        var comp = Context.Component.Single();

            Assert.AreEqual(_cmd.Name, comp.Name);
            Assert.AreEqual(_cmd.MinimumStock, comp.MinimumStock);
            Assert.AreEqual(_cmd.Quantity, comp.Stock);
            Assert.AreEqual(_cmd.Stocknr, comp.Stocknr);
            Assert.AreEqual(_cmd.Price, comp.Price);
            Assert.AreEqual(_cmd.SupplierId, comp.SupplierId);
            Assert.AreEqual(_cmd.Remarks, comp.Remarks);
			Assert.AreEqual(_cmd.ItemCode, comp.ItemCode);
        }
    }
}