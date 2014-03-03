using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DAL.Component.FilterComponent;

namespace Tests.Components.FilterComponent.FilterStockQueryExecutor
{
    [TestFixture]
    public class WhenExecuteIsCalledForShortage : DatabaseTest
    {
        private FilterComponentRequestExecutorExecutor _sut;
        private FilterComponentRequest _req;
        private FilterComponentResponse _resp;
	    private Component _c1, _c2, _c3, _c4;

        public override void Arrange()
        {
            _req = new FilterComponentRequest
            {
	            Shortage = true
            };
            var s = new Supplier
            {
                Name = "Musikding"
            };
            Context.Supplier.AddObject(s);
            Context.SaveChanges();

            _c1 = new Component
            {
                Name = "Weerstand 180 Ohm klein",
                Stocknr = "R180E1",
                Price = 0.04M,
                Stock = 10,
                MinimumStock = 5,
                Remarks = "blah",
                SupplierId = s.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(_c1);

            _c2 = new Component
            {
                Name = "Weerstand 180 Ohm groot",
                Stocknr = "R180E2",
                Price = 0.05M,
                Stock = 10,
                MinimumStock = 10,
                Remarks = "blahblah",
				SupplierId = s.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(_c2);

            _c3 = new Component
            {
                Name = "Weerstand 180 Ohm groot",
                Stocknr = "R180E3",
                Price = 0.05M,
                Stock = 10,
                MinimumStock = 15,
                Remarks = "blahblah",
				SupplierId = s.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(_c3);

            _c4 = new Component
            {
                Name = "Weerstand 180 Ohm groot",
                Stocknr = "R180E4",
                Price = 0.05M,
                Stock = 10,
                MinimumStock = 20,
                Remarks = "blahblah",
				SupplierId = s.Id,
				ItemCode = "abc1235"
            };
            Context.Component.AddObject(_c4);

            _sut = new FilterComponentRequestExecutorExecutor(Context);
        }

        public override void Act()
        {
            _resp = _sut.Execute(_req);
        }

        [Test]
        public void It_should_return_the_correct_Components()
        {
            Assert.IsFalse(_resp.Components.Any(x => x.Stocknr.Equals(_c1.Stocknr)));
			Assert.IsFalse(_resp.Components.Any(x => x.Stocknr.Equals(_c2.Stocknr)));
			Assert.IsTrue(_resp.Components.Any(x => x.Stocknr.Equals(_c3.Stocknr)));
			Assert.IsTrue(_resp.Components.Any(x => x.Stocknr.Equals(_c4.Stocknr)));
        }
    }
}