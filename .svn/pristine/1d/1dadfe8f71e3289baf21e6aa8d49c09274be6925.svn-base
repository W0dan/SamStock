using System.Linq;
using NUnit.Framework;
using SAMStock.DAL.Pedal.AddPedal;

namespace Tests.Pedals.AddPedal.AddPedalCommandExecutor
{
	[TestFixture]
	public class WhenExecuteIsCalled : DatabaseTest
	{
		private AddPedalCommand _cmd;
		private SAMStock.DAL.Pedal.AddPedal.AddPedalCommandExecutor _sut;

		public override void Arrange()
		{
			_cmd = new AddPedalCommand
			{
				Margin = 10,
				Name = "Blaster",
				Price = 50
			};

			_sut = new SAMStock.DAL.Pedal.AddPedal.AddPedalCommandExecutor(Context);
		}

		public override void Act()
		{
			_sut.Execute(_cmd);
		}

		[Test]
		public void It_should_add_the_Pedal()
		{
			Assert.AreEqual(1, Context.Pedal.Count(p => p.Name == _cmd.Name && p.Margin == _cmd.Margin && p.Price == _cmd.Price));
		}
	}
}
