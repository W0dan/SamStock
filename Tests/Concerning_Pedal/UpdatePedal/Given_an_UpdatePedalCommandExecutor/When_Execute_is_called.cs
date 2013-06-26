using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SamStock.Pedal.UpdatePedal;
using SamStock.Database;

namespace Tests.Concerning_Pedal.UpdatePedal.Given_an_UpdatePedalCommandExecutor
{
	[TestFixture]
	public class When_Execute_is_called : DatabaseTest
	{
		private IUpdatePedalCommandExecutor _executor;

		public override void Arrange()
		{
			_executor = new UpdatePedalCommandExecutor(Context);

			Context.Pedal.AddObject(new Pedal
			{
				Name = "Blaster",
				Price = 50.0M,
				Margin = 20.0M
			});
			Context.SaveChanges();
		}

		public override void Act()
		{
			_executor.Execute(new UpdatePedalCommand(Context.Pedal.Single().Id, "Fuzzer", 20.0M, 10.0M));
		}

		[Test]
		public void It_should_update_the_Pedal()
		{
			Assert.AreEqual(1, Context.Pedal.Count());
			var pedal = Context.Pedal.Single();
			Assert.IsTrue(pedal.Name == "Fuzzer" && pedal.Price == 20.0M && pedal.Margin == 10.0M);
		}
	}
}
