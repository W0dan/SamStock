using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAMStock.Pedal.AddPedal;
using Moq;

namespace Tests.Concerning_Pedal.AddPedal.Given_an_AddPedalHandler
{
	[TestFixture]
	public class When_Handle_is_called : BaseTest
	{
		private AddPedalCommand _request;
		private IAddPedalHandler _sut;
		private Mock<IAddPedalCommandExecutor> _queryexecutor;

		public override void Arrange()
		{
			_request = new AddPedalCommand("Blaster", 50.0M, 25.0M);
			_queryexecutor = new Mock<IAddPedalCommandExecutor>();
			_sut = new AddPedalHandler(_queryexecutor.Object);
		}

		public override void Act()
		{
			_sut.Handle(_request);
		}

		[Test]
		public void It_should_call_Execute_on_the_AddPedalCommandExecutor()
		{
			_queryexecutor.Verify(x => x.Execute(_request));
		}
	}
}
