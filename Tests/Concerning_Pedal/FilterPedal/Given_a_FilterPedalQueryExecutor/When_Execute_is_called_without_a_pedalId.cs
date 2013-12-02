using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAMStock.Pedal.FilterPedal;
using SAMStock.Database;

namespace Tests.Concerning_Pedal.FilterPedal.Given_a_FilterPedalQueryExecutor
{
	[TestFixture]
    public class When_Execute_is_called_without_a_pedalId : DatabaseTest
	{
		private IFilterPedalQueryExecutor _sut;
		private FilterPedalRequest _request;
		private FilterPedalResponse _response;
		private Component comp1;
		private Pedal p1;
		private PedalComponent pc1;
		private Supplier s1;

		public override void Arrange()
		{
			_sut = new FilterPedalQueryExecutor(Context);

			s1 = new Supplier
			{
				Name = "Jos",
				Id = 1,
				Address = "somewhere"
			};
			Context.Supplier.AddObject(s1);

			comp1 = new Component
			{
				Stocknr = "ABC1",
				Price = 5.0M,
				SupplierId = s1.Id,
				Stock = 20,
				MinimumStock = 15,
				Name = "something",
				Id = 1,
				Remarks = "blabla",
				ItemCode = "abc1235"
			};
			Context.Component.AddObject(comp1);
			Context.Component.AddObject(new Component
			{
				Stocknr = "xyz",
				Price = 20.0M,
				SupplierId = comp1.SupplierId,
				Stock = 10,
				MinimumStock = 15,
				Name = "something else",
				Id = comp1.Id + 1,
				Remarks = "blabla",
				ItemCode = "abc1235"
			});

			p1 = new Pedal
			{
				Name = "Blaster",
				Id = 1,
				Price = 5.0M,
				Margin = 2.0M
			};
			Context.Pedal.AddObject(p1);
			Context.Pedal.AddObject(new Pedal
			{
				Name = "Fuzzer",
				Id = p1.Id + 1,
				Price = 10.0M,
				Margin = 7.0M
			});

			pc1 = new PedalComponent
			{
				Id = 1,
				PedalId = p1.Id,
				ComponentId = comp1.Id,
				Number = 3
			};
			Context.PedalComponent.AddObject(pc1);

			Context.SaveChanges();

			_request = new FilterPedalRequest(0);
		}

		public override void Act()
		{
			_response = _sut.Execute(_request);
		}

		[Test]
		public void It_should_return_all_pedals()
		{
			Assert.AreEqual(2, _response.Pedals.Count);
		}

		[Test]
		public void It_should_contain_a_valid_pedal_and_its_data()
		{
			Assert.IsTrue(_response.Pedals.Any(x => x.Name == p1.Name && x.Price == p1.Price && x.Margin == p1.Margin && x.Id == p1.Id));
		}

		[Test]
		public void It_should_return_1_component()
		{
			Assert.AreEqual(1,_response.Pedals[0].Components.Count());
		}

		[Test]
		public void It_should_contain_the_pedals_component()
		{
			Assert.IsTrue(_response.Pedals[0].Components.All(x => x.Description == comp1.Name && x.Price == comp1.Price && x.Quantity == pc1.Number && x.Stocknr == comp1.Stocknr));
		}
	}
}
