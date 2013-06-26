using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using SamStock.Pedal.UpdatePedal;

namespace Tests.Concerning_Pedal.UpdatePedal.Given_an_UpdatePedalHandler
{
	[TestFixture]
	public class When_Handle_is_called : BaseTest
	{
		private Mock<IUpdatePedalCommandExecutor> _executor;
		private IUpdatePedalHandler _sut;

		public override void Arrange()
		{
			_executor = new Mock<IUpdatePedalCommandExecutor>();
			_sut = new UpdatePedalHandler(_executor.Object);
		}

		public override void Act()
		{
			_sut.Handle(new UpdatePedalCommand(0, "Blaster", 20.0M, 10.0M));
		}

		[Test]
		public void It_should_call_Execute_on_the_Executor()
		{
			_executor.Verify(x => x.Execute(It.IsAny<UpdatePedalCommand>()));
		}
	}
}
