using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DAL.Pedal.FilterPedal;

namespace Tests.Pedals.FilterPedal.FilterPedalQueryExecutor
{
	[TestFixture]
    public class WhenExecuteIsCalled : DatabaseTest
	{
		private FilterPedalRequestExecutor _sut;
		private FilterPedalRequest _request;
		private FilterPedalResponse _response;
		private Component _c1;
		private Pedal _p1;
		private PedalComponent _pc1;
		private Supplier _s1;

		public override void Arrange()
		{
			_sut = new SAMStock.DAL.Pedal.FilterPedal.FilterPedalRequestExecutor(Context);

			_s1 = new Supplier
			{
				Name = "Jos",
				Address = "somewhere"
			};
			Context.Supplier.AddObject(_s1);
			Context.SaveChanges();

			_c1 = new Component
			{
				Stocknr = "ABC1",
				Price = 5.0M,
				SupplierId = Context.Supplier.Single().Id,
				Stock = 20,
				MinimumStock = 15,
				Name = "something",
				ItemCode = "abc1235"
			};
			Context.Component.AddObject(_c1);
			Context.Component.AddObject(new Component
			{
				Stocknr = "xyz",
				Price = 20.0M,
				SupplierId = _c1.SupplierId,
				Stock = 10,
				MinimumStock = 15,
				Name = "something else",
				ItemCode = "abc1235"
			});

			_p1 = new Pedal
			{
				Name = "Blaster",
				Price = 5.0M,
			};
			Context.Pedal.AddObject(_p1);
			Context.Pedal.AddObject(new Pedal
			{
				Name = "Fuzzer",
				Price = 10.0M,
				Margin = 7.0M
			});
			Context.SaveChanges();

			_pc1 = new PedalComponent
			{
				PedalId = Context.Pedal.Single(x => x.Name.Equals(_p1.Name)).Id,
				ComponentId = Context.Component.Single(x => x.Stocknr.Equals(_c1.Stocknr)).Id,
				Number = 3
			};
			Context.PedalComponent.AddObject(_pc1);

			_request = new FilterPedalRequest();
		}

		public override void Act()
		{
			_response = _sut.Execute(_request);
		}

		[Test]
		public void It_should_return_all_pedals()
		{
			Assert.AreEqual(2, _response.Pedals.Count);
			Assert.IsTrue(_response.Pedals.Any(x => x.Name.Equals(_p1.Name) && x.Price == _p1.Price && x.Margin == _p1.Margin));
		}

		[Test]
		public void It_should_return_the_Pedals_Components()
		{
			var ids = _response.Pedals.Single(x => x.Name.Equals(_p1.Name)).Components;
			var c1Id = Context.Component.Single(x => x.Stocknr.Equals(_c1.Stocknr)).Id;
			Assert.AreEqual(ids.Count, 1);
			Assert.IsTrue(ids.Any(x => x.Id == c1Id));
		}
	}
}
