using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SamStock.Pedal.AddPedal;
using SamStock.Database;

namespace Tests.Concerning_Pedal.AddPedal.Given_an_AddPedalCommandExecutor
{
	[TestFixture]
	public class When_Execute_is_called : DatabaseTest
	{
		private AddPedalCommand _cmd;
		private IAddPedalCommandExecutor _sut;

		public override void Arrange()
		{
			_cmd = new AddPedalCommand("Blaster", 50.0M, 25.0M);
			_sut = new AddPedalCommandExecutor(Context);
		}

		public override void Act()
		{
			_sut.Execute(_cmd);
		}

		[Test]
		public void It_should_add_the_item()
		{
			Assert.AreEqual(1, Context.Pedal.Count(p => p.Name == _cmd.Name && p.Margin == _cmd.Margin && _cmd.Price == _cmd.Price));
		}
	}
}
