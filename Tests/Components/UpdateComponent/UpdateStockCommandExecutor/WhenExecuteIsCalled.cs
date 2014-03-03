using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DAL.Component.UpdateComponent;

namespace Tests.Components.UpdateComponent.UpdateStockCommandExecutor
{
    [TestFixture]
    public class WhenExecuteIsCalled : DatabaseTest
    {
        private UpdateComponentCommandExecutor _sut;
        private UpdateComponentCommand _cmd;
	    private Component _c1, _c2;

        public override void Arrange()
        {
            var s = new Supplier
                {
                    Name = "MusikDing",
                };
            Context.Supplier.AddObject(s);
	        Context.SaveChanges();

	        _c1 = new Component
	        {
		        Stocknr = "a15",
		        Name = "weerstand",
		        SupplierId = Context.Supplier.Single().Id,
		        Stock = 10,
		        ItemCode = "abc1235",
				MinimumStock = 5,
				Price = 10
	        };
	        _c2 = new Component
	        {
		        Stocknr = "b15",
		        Name = "condensator",
				SupplierId = Context.Supplier.Single().Id,
		        Stock = 10,
		        Price = 1,
		        ItemCode = "abc1235",
				MinimumStock = 20
	        };
            Context.Component.AddObject(_c1);
            Context.Component.AddObject(_c2);
	        Context.SaveChanges();

            _cmd = new UpdateComponentCommand
            {
	            Id = Context.Component.Single(x => x.Stocknr == _c1.Stocknr).Id,
				MinimumStock = 10
            };
            _sut = new UpdateComponentCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_cmd);
        }

	    [Test]
	    public void It_should_update_the_right_Component()
	    {
		    Assert.AreEqual(_cmd.MinimumStock, Context.Component.Single(x => x.Stocknr == _c1.Stocknr).MinimumStock);
			Assert.AreEqual(_c2.MinimumStock, Context.Component.Single(x => x.Stocknr == _c2.Stocknr).MinimumStock);
	    }
    }
}