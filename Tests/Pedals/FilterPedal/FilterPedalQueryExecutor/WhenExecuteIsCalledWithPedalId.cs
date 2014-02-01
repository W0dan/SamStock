using System.Linq;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DTO.Pedal.FilterPedal;

namespace Tests.Pedals.FilterPedal.FilterPedalQueryExecutor
{
	[TestFixture]
	public class WhenExecuteIsCalledWithPedalId : DatabaseTest
	{
		private IFilterPedalRequestExecutorExecutor _sut;
		private FilterPedalRequest _req;
		private FilterPedalResponse _resp;
		private Pedal _p1;

		public override void Arrange()
		{
			_sut = new SAMStock.DTO.Pedal.FilterPedal.FilterPedalRequestExecutor(Context);

			_p1 = new Pedal
			{
				Name = "Blaster",
				Price = 5.0M
			};
			Context.Pedal.AddObject(_p1);
			Context.Pedal.AddObject(new Pedal
			{
				Name = "Fuzzer",
				Price = 10.0M,
				Margin = 7.0M
			});
			Context.SaveChanges();

			_req = new FilterPedalRequest
			{
				Id = Context.Pedal.Single(x => x.Name.Equals(_p1.Name)).Id
			};
		}

		public override void Act()
		{
			_resp = _sut.Execute(_req);
		}

		[Test]
		public void It_should_return_the_correct_Pedal()
		{
			Assert.IsTrue(_resp.Pedals.All(x => x.Name.Equals(_p1.Name)));
		}
	}
}
